using DataCheck.Core;
using DataCheck.Core.Pravidla;

namespace DataCheck.Tests
{
    public class NazevNeniPrazdnyTests
    {
        [Fact]
        public void VyplnenyNazev_VratiNull()
        {
            var pravidlo = new NazevNeniPrazdny();
            var subjekt = new Zakaznik(1, "Ordinace Novák");

            var nalez = pravidlo.Zkontroluj(subjekt);

            Assert.Null(nalez);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData("\t")]
        public void PrazdnyNazev_VratiNalez(string nazev)
        {
            var pravidlo = new NazevNeniPrazdny();
            var subjekt = new Zakaznik(1, nazev);

            var nalez = pravidlo.Zkontroluj(subjekt);

            Assert.NotNull(nalez);
            Assert.Equal("NAZEV_PRAZDNY", nalez.KodPravidla);
        }
    }
}