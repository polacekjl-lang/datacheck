namespace DataCheck.Core.Pravidla
{
    public class PscMaPetCislic : IPravidlo
    {
        public string Kod => "PSC_FORMAT";
        public Zavaznost Zavaznost => Zavaznost.Varovani;

        public Nalez? Zkontroluj(Subjekt subjekt)
        {
            if (string.IsNullOrWhiteSpace(subjekt.Psc))
            {
                return null;
            }

            var psc = subjekt.Psc.Replace(" ", "");

            if (psc.Length != 5)
            {
                return new Nalez(subjekt.Id, Kod, Zavaznost,
                    $"PSČ má {psc.Length} číslic, očekáváno 5");
            }

            foreach (char znak in psc)
            {
                if (!char.IsDigit(znak))
                {
                    return new Nalez(subjekt.Id, Kod, Zavaznost,
                        $"PSČ obsahuje nečíselný znak: {znak}");
                }
            }

            return null;
        }
    }
}