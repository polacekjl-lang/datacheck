using DataCheck.Core;
using DataCheck.Core.Pravidla;

var subjektRepo = new SubjektRepository(DbNastaveni.ConnectionString);
var nalezRepo = new NalezRepository(DbNastaveni.ConnectionString);

var subjekty = subjektRepo.NactiVsechny();
Console.WriteLine($"Načteno z databáze: {subjekty.Count} subjektů");

var pravidla = new List<IPravidlo>
{
    new NazevNeniPrazdny(),
    new IcoMaOsmCislic(),
    new PscMaPetCislic()
};

var kontrolor = new Kontrolor(pravidla);
var nalezy = kontrolor.Zkontroluj(subjekty);

Console.WriteLine($"Nalezeno problémů: {nalezy.Count}");

nalezRepo.UlozVse(nalezy);
Console.WriteLine("Nálezy uloženy do databáze.");
Console.WriteLine();

foreach (var nalez in nalezy)
{
    Console.WriteLine(nalez);
}