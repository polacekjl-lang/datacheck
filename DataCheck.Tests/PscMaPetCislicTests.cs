using DataCheck.Core;
using DataCheck.Core.Pravidla;

namespace DataCheck.Tests
{
    public class PscMaPetCislicTests
    {
        [Theory]
        [InlineData("57001")]
        [InlineData("570 01")]
        public void PlatnePsc_VratiNull(string psc)
        {
            var pravidlo = new PscMaPetCislic();
            var subjekt = new Zakaznik(1, "Test") { Psc = psc };

            var nalez = pravidlo.Zkontroluj(subjekt);

            Assert.Null(nalez);
        }

        [Theory]
        [InlineData("5700")]
        [InlineData("570011")]
        [InlineData("5700A")]
        public void NeplatnePsc_VratiNalez(string psc)
        {
            var pravidlo = new PscMaPetCislic();
            var subjekt = new Zakaznik(1, "Test") { Psc = psc };

            var nalez = pravidlo.Zkontroluj(subjekt);

            Assert.NotNull(nalez);
            Assert.Equal("PSC_FORMAT", nalez.KodPravidla);
        }

        [Fact]
        public void PrazdnePsc_VratiNull()
        {
            var pravidlo = new PscMaPetCislic();
            var subjekt = new Zakaznik(1, "Test");

            var nalez = pravidlo.Zkontroluj(subjekt);

            Assert.Null(nalez);
        }
    }
}