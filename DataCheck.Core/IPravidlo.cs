namespace DataCheck.Core
{
    public interface IPravidlo
    {
        string Kod { get; }
        Zavaznost Zavaznost { get; }
        Nalez? Zkontroluj(Subjekt subjekt);
    }
}