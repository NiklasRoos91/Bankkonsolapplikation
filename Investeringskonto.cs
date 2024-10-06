namespace BankkonsolapplikationW2
{
    public class Investeringskonto : Bankkonto
    {
        public Investeringskonto(string AccountHolderName, int AccountNumber, double AccountBalance) : base(AccountHolderName, AccountNumber, AccountBalance) 
        {
        }

        public override string AccountType()
        {
            return "Investeringskonto";
        }
    }
}
