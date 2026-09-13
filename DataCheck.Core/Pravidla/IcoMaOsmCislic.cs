namespace DataCheck.Core.Pravidla
{
    public class IcoMaOsmCislic : IPravidlo
    {
        public string Kod => "ICO_DELKA";
        public Zavaznost Zavaznost => Zavaznost.Chyba;

        public Nalez? Zkontroluj(Subjekt subjekt)
        {
            if (string.IsNullOrWhiteSpace(subjekt.Ico))
            {
                return null;
            }

            if (subjekt.Ico.Length != 8)
            {
                return new Nalez(subjekt.Id, Kod, Zavaznost,
                    $"IČO má {subjekt.Ico.Length} znaků, očekáváno 8");
            }

            foreach (char znak in subjekt.Ico)
            {
                if (!char.IsDigit(znak))
                {
                    return new Nalez(subjekt.Id, Kod, Zavaznost,
                        $"IČO obsahuje nečíselný znak: {znak}");
                }
            }

            return null;
        }
    }
}