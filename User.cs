namespace BankkonsolapplikationW2
{
    public class User
    {
        public Personkonto personKonto;

        public Sparkonto sparKonto;

        public Investeringskonto investeringsKonto;
        public User(Personkonto personKonto, Sparkonto sparKonto, Investeringskonto investeringsKonto)
        {
            this.personKonto = personKonto;
            this.sparKonto = sparKonto;
            this.investeringsKonto = investeringsKonto;
        }
    }
}
