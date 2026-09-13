using DataCheck.Core;

namespace DataCheck.Tests
{
    public class SubjektTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void NeplatneId_VyhodiVyjimku(int id)
        {
            Assert.Throws<ArgumentException>(() => new Zakaznik(id, "Test"));
        }

        [Fact]
        public void DodavatelBezIco_VyhodiVyjimku()
        {
            Assert.Throws<ArgumentException>(() => new Dodavatel(1, "Test", ""));
        }

        [Fact]
        public void DodavatelSeVsemUdaji_MaPovinneUdaje()
        {
            var dodavatel = new Dodavatel(1, "Test s.r.o.", "12345678")
            {
                CisloUctu = "123456789/0800"
            };

            Assert.True(dodavatel.MaPovinneUdaje());
        }

        [Fact]
        public void DodavatelBezUctu_NemaPovinneUdaje()
        {
            var dodavatel = new Dodavatel(1, "Test s.r.o.", "12345678");

            Assert.False(dodavatel.MaPovinneUdaje());
        }

        [Fact]
        public void ZakaznikSNazvem_MaPovinneUdaje()
        {
            var zakaznik = new Zakaznik(1, "Ordinace Novák");

            Assert.True(zakaznik.MaPovinneUdaje());
        }

        [Fact]
        public void ZakaznikBezNazvu_NemaPovinneUdaje()
        {
            var zakaznik = new Zakaznik(1, "   ");

            Assert.False(zakaznik.MaPovinneUdaje());
        }
    }
}