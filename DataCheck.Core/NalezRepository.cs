using Microsoft.Data.SqlClient;

namespace DataCheck.Core
{
    public class NalezRepository
    {
        private readonly string _connectionString;

        public NalezRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Nalez> NactiVsechny()
        {
            var nalezy = new List<Nalez>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var sql = @"SELECT SubjektId, KodPravidla, Zavaznost, Popis, Zjisteno
                        FROM Nalezy
                        ORDER BY Zjisteno DESC";

            using var command = new SqlCommand(sql, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                nalezy.Add(new Nalez(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    Enum.Parse<Zavaznost>(reader.GetString(2)),
                    reader.GetString(3),
                    reader.GetDateTime(4)));
            }

            return nalezy;
        }

        public void NahradVse(List<Nalez> nalezy)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var transaction = connection.BeginTransaction();

            try
            {
                using (var smazat = new SqlCommand("DELETE FROM Nalezy", connection, transaction))
                {
                    smazat.ExecuteNonQuery();
                }

                var sql = @"INSERT INTO Nalezy (SubjektId, KodPravidla, Zavaznost, Popis, Zjisteno)
                            VALUES (@SubjektId, @KodPravidla, @Zavaznost, @Popis, @Zjisteno)";

                foreach (var nalez in nalezy)
                {
                    using var command = new SqlCommand(sql, connection, transaction);

                    command.Parameters.AddWithValue("@SubjektId", nalez.SubjektId);
                    command.Parameters.AddWithValue("@KodPravidla", nalez.KodPravidla);
                    command.Parameters.AddWithValue("@Zavaznost", nalez.Zavaznost.ToString());
                    command.Parameters.AddWithValue("@Popis", nalez.Popis);
                    command.Parameters.AddWithValue("@Zjisteno", nalez.Zjisteno);

                    command.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}