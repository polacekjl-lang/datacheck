using DataCheck.Core;

var dodavatel = new Dodavatel(1, "Dentimed s.r.o.", "00023001")
{
    Mesto = "Litomyšl",
    Psc = "57001",
    CisloUctu = "123456789/0800",
    JePlatceDph = true
};

var zakaznik = new Zakaznik(2, "Ordinace Novák")
{
    Mesto = "Tábor",
    KodPojistovny = "111"
};

List<Subjekt> vsechny = new List<Subjekt> { dodavatel, zakaznik };

foreach (var s in vsechny)
{
    Console.WriteLine(s.Popis());
}