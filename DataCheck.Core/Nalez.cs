namespace DataCheck.Core
{
    public enum Zavaznost
    {
        Informace,
        Varovani,
        Chyba
    }

    public class Nalez
    {
        public int SubjektId { get; private set; }
        public string KodPravidla { get; private set; }
        public Zavaznost Zavaznost { get; private set; }
        public string Popis { get; private set; }
        public DateTime Zjisteno { get; private set; }

        // Vznik nového nálezu při kontrole
        public Nalez(int subjektId, string kodPravidla, Zavaznost zavaznost, string popis)
            : this(subjektId, kodPravidla, zavaznost, popis, DateTime.Now)
        {
        }

        // Načtení existujícího nálezu z databáze
        public Nalez(int subjektId, string kodPravidla, Zavaznost zavaznost, string popis, DateTime zjisteno)
        {
            SubjektId = subjektId;
            KodPravidla = kodPravidla;
            Zavaznost = zavaznost;
            Popis = popis;
            Zjisteno = zjisteno;
        }

        public override string ToString()
        {
            return $"[{Zavaznost}] {KodPravidla} u subjektu {SubjektId}: {Popis}";
        }
    }
}