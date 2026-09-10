namespace DataCheck.Core
{
    public class Zakaznik : Subjekt
    {
        public string? KodPojistovny { get; set; }

        public Zakaznik(int id, string nazev)
            : base(id, nazev)
        {
        }
    }
}