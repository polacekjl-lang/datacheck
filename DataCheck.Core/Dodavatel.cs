namespace DataCheck.Core
{
    public class Dodavatel : Subjekt
    {
        public string? CisloUctu { get; set; }
        public bool JePlatceDph { get; set; }

        public Dodavatel(int id, string nazev, string ico)
            : base(id, nazev)
        {
            if (string.IsNullOrWhiteSpace(ico))
                throw new ArgumentException("Dodavatel musí mít IČO", nameof(ico));

            Ico = ico;
        }

        public override string Popis()
        {
            return $"Dodavatel {Nazev} (IČO {Ico}), účet: {CisloUctu ?? "chybí"}";
        }

        public override bool MaPovinneUdaje()
        {
            return !string.IsNullOrWhiteSpace(Nazev)
                && !string.IsNullOrWhiteSpace(Ico)
                && !string.IsNullOrWhiteSpace(CisloUctu);
        }
    }
}