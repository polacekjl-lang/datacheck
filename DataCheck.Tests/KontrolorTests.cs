using DataCheck.Core;

namespace DataCheck.Tests
{
    public class FalesnePravidlo : IPravidlo
    {
        public string Kod => "TEST";
        public Zavaznost Zavaznost => Zavaznost.Informace;
        public int PocetVolani { get; private set; }

        public Nalez? Zkontroluj(Subjekt subjekt)
        {
            PocetVolani++;
            return new Nalez(subjekt.Id, Kod, Zavaznost, "Testovací nález");
        }
    }

    public class KontrolorTests
    {
        [Fact]
        public void Kontrolor_ZavolaKazdePravidloNaKazdySubjekt()
        {
            var pravidlo = new FalesnePravidlo();
            var kontrolor = new Kontrolor(new List<IPravidlo> { pravidlo });

            var subjekty = new List<Subjekt>
            {
                new Zakaznik(1, "První"),
                new Zakaznik(2, "Druhý"),
                new Zakaznik(3, "Třetí")
            };

            var nalezy = kontrolor.Zkontroluj(subjekty);

            Assert.Equal(3, pravidlo.PocetVolani);
            Assert.Equal(3, nalezy.Count);
        }

        [Fact]
        public void Kontrolor_BezPravidel_VratiPrazdnySeznam()
        {
            var kontrolor = new Kontrolor(new List<IPravidlo>());
            var subjekty = new List<Subjekt> { new Zakaznik(1, "Test") };

            var nalezy = kontrolor.Zkontroluj(subjekty);

            Assert.Empty(nalezy);
        }
    }
}