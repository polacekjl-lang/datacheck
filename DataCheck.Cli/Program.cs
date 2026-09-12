using DataCheck.Core;
using DataCheck.Core.Pravidla;

var subjekty = new List<Subjekt>
{
    new Dodavatel(1, "Dentimed s.r.o.", "00023001")
    {
        Mesto = "Litomyšl",
        Psc = "57001",
        CisloUctu = "123456789/0800"
    },
    new Dodavatel(2, "Špatné IČO s.r.o.", "1234"),
    new Dodavatel(3, "Písmena v IČO", "ABCD1234"),
    new Zakaznik(4, "Ordinace Novák") { KodPojistovny = "111" },
    new Zakaznik(5, "   ")
};

var pravidla = new List<IPravidlo>
{
    new NazevNeniPrazdny(),
    new IcoMaOsmCislic()
};

var kontrolor = new Kontrolor(pravidla);
var nalezy = kontrolor.Zkontroluj(subjekty);

Console.WriteLine($"Zkontrolováno subjektů: {subjekty.Count}");
Console.WriteLine($"Nalezeno problémů: {nalezy.Count}");
Console.WriteLine();

foreach (var nalez in nalezy)
{
    Console.WriteLine(nalez);
}