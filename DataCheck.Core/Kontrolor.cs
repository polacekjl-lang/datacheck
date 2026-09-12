namespace DataCheck.Core
{
    public class Kontrolor
    {
        private readonly List<IPravidlo> _pravidla;

        public Kontrolor(List<IPravidlo> pravidla)
        {
            _pravidla = pravidla;
        }

        public List<Nalez> Zkontroluj(List<Subjekt> subjekty)
        {
            var nalezy = new List<Nalez>();

            foreach (var subjekt in subjekty)
            {
                foreach (var pravidlo in _pravidla)
                {
                    var nalez = pravidlo.Zkontroluj(subjekt);

                    if (nalez != null)
                    {
                        nalezy.Add(nalez);
                    }
                }
            }

            return nalezy;
        }
    }
}