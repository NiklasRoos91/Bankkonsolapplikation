namespace BankkonsolapplikationW2
{
    public class Transaktionshistorik
    {
        public DateTime förstaTransaktion;

        public DateTime sistaTransaktion;

        public Transaktionshistorik()
        {
            förstaTransaktion = DateTime.Now;
            sistaTransaktion = DateTime.Now;
        }

        // påbörja transferhistoriken men kände att jag inte skulle få ihop det som jag ville och verkligen förstå vad jag gjort på tiden jag hade så jag sluta för tillfället.
    }
}
