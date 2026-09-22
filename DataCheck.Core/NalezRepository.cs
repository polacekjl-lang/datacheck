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

        public void UlozVse(List<Nalez> nalezy)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var sql = @"INSERT INTO Nalezy (SubjektId, KodPravidla, Zavaznost, Popis, Zjisteno)
                        VALUES (@SubjektId, @KodPravidla, @Zavaznost, @Popis, @Zjisteno)";

            foreach (var nalez in nalezy)
            {
                using var command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@SubjektId", nalez.SubjektId);
                command.Parameters.AddWithValue("@KodPravidla", nalez.KodPravidla);
                command.Parameters.AddWithValue("@Zavaznost", nalez.Zavaznost.ToString());
                command.Parameters.AddWithValue("@Popis", nalez.Popis);
                command.Parameters.AddWithValue("@Zjisteno", nalez.Zjisteno);

                command.ExecuteNonQuery();
            }
        }
    }
}