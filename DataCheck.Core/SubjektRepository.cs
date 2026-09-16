using Microsoft.Data.SqlClient;

namespace DataCheck.Core
{
    public class SubjektRepository
    {
        private readonly string _connectionString;

        public SubjektRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Subjekt> NactiVsechny()
        {
            var subjekty = new List<Subjekt>();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var sql = @"SELECT Id, Typ, Nazev, Ico, Mesto, Psc, Email,
                               CisloUctu, JePlatceDph, KodPojistovny
                        FROM Subjekty
                        ORDER BY Id";

            using var command = new SqlCommand(sql, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                subjekty.Add(VytvorSubjekt(reader));
            }

            return subjekty;
        }

        private Subjekt VytvorSubjekt(SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            string typ = reader.GetString(1);
            string nazev = reader.GetString(2);
            string? ico = reader.IsDBNull(3) ? null : reader.GetString(3);

            Subjekt subjekt;

            if (typ == "Dodavatel")
            {
                subjekt = new Dodavatel(id, nazev, ico ?? "neuvedeno")
                {
                    CisloUctu = reader.IsDBNull(7) ? null : reader.GetString(7),
                    JePlatceDph = reader.GetBoolean(8)
                };
            }
            else
            {
                subjekt = new Zakaznik(id, nazev)
                {
                    KodPojistovny = reader.IsDBNull(9) ? null : reader.GetString(9)
                };
            }

            subjekt.Ico = ico;
            subjekt.Mesto = reader.IsDBNull(4) ? null : reader.GetString(4);
            subjekt.Psc = reader.IsDBNull(5) ? null : reader.GetString(5);
            subjekt.Email = reader.IsDBNull(6) ? null : reader.GetString(6);

            return subjekt;
        }
    }
}