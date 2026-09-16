using DataCheck.Core;
using DataCheck.Core.Pravidla;

var repository = new SubjektRepository(DbNastaveni.ConnectionString);
var subjekty = repository.NactiVsechny();

Console.WriteLine($"Načteno z databáze: {subjekty.Count} subjektů");
Console.WriteLine();

var pravidla = new List<IPravidlo>
{
    new NazevNeniPrazdny(),
    new IcoMaOsmCislic(),
    new PscMaPetCislic()
};

var kontrolor = new Kontrolor(pravidla);
var nalezy = kontrolor.Zkontroluj(subjekty);

Console.WriteLine($"Nalezeno problémů: {nalezy.Count}");
Console.WriteLine();

foreach (var nalez in nalezy)
{
    Console.WriteLine(nalez);
}