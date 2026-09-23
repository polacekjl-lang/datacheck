namespace DataCheck.Core
{
    public abstract class Subjekt
    {
        public int Id { get; private set; }
        public string Nazev { get; set; }
        public string? Ico { get; set; }
        public string? Mesto { get; set; }
        public string? Psc { get; set; }
        public string? Email { get; set; }

        public Subjekt(int id, string nazev)
        {
            if (id <= 0)
                throw new ArgumentException("Id musí být kladné číslo", nameof(id));

            Id = id;
            Nazev = nazev;
        }

        public abstract string Popis();

        public abstract bool MaPovinneUdaje();

        public string Typ => GetType().Name;

        public override string ToString()
        {
            return $"[{Id}] {Nazev} (IČO: {Ico ?? "neuvedeno"})";
        }
    }
}