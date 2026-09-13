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

        public Nalez(int subjektId, string kodPravidla, Zavaznost zavaznost, string popis)
        {
            SubjektId = subjektId;
            KodPravidla = kodPravidla;
            Zavaznost = zavaznost;
            Popis = popis;
            Zjisteno = DateTime.Now;
        }

        public override string ToString()
        {
            return $"[{Zavaznost}] {KodPravidla} u subjektu {SubjektId}: {Popis}";
        }
    }
}