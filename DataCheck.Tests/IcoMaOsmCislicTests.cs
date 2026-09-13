using DataCheck.Core;
using DataCheck.Core.Pravidla;

namespace DataCheck.Tests
{
    public class IcoMaOsmCislicTests
    {
        [Fact]
        public void PlatneIco_VratiNull()
        {
            // Arrange
            var pravidlo = new IcoMaOsmCislic();
            var subjekt = new Dodavatel(1, "Test s.r.o.", "12345678");

            // Act
            var nalez = pravidlo.Zkontroluj(subjekt);

            // Assert
            Assert.Null(nalez);
        }

        [Fact]
        public void KratkeIco_VratiNalez()
        {
            var pravidlo = new IcoMaOsmCislic();
            var subjekt = new Dodavatel(1, "Test s.r.o.", "1234");

            var nalez = pravidlo.Zkontroluj(subjekt);

            Assert.NotNull(nalez);
            Assert.Equal("ICO_DELKA", nalez.KodPravidla);
            Assert.Equal(Zavaznost.Chyba, nalez.Zavaznost);
        }

        [Fact]
        public void IcoSPismeny_VratiNalez()
        {
            var pravidlo = new IcoMaOsmCislic();
            var subjekt = new Dodavatel(1, "Test s.r.o.", "ABCD1234");

            var nalez = pravidlo.Zkontroluj(subjekt);

            Assert.NotNull(nalez);
        }
    }
}