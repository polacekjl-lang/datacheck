

namespace DataCheck.Core
{
    public class Dodavatel : Subjekt
    {
        public string? CisloUctu { get; set; }
        public bool JePlatceDph {  get; set; }

        public Dodavatel(int id, string nazev, string ico)
            : base(id, nazev)
        {
            if (string.IsNullOrWhiteSpace(ico))
                throw new ArgumentNullException("Dodavatel musí mít IČO", nameof(ico));

            Ico = ico;

        }
    }
}


