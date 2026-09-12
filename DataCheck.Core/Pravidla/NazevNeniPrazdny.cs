namespace DataCheck.Core.Pravidla
{
    public class NazevNeniPrazdny : IPravidlo
    {
        public string Kod => "NAZEV_PRAZDNY";
        public Zavaznost Zavaznost => Zavaznost.Chyba;

        public Nalez? Zkontroluj(Subjekt subjekt)
        {
            if (string.IsNullOrWhiteSpace(subjekt.Nazev))
            {
                return new Nalez(subjekt.Id, Kod, Zavaznost,
                    "Název subjektu je prázdný");
            }

            return null;
        }
    }
}