namespace BankkonsolapplikationW2
{
    public class Sparkonto : Bankkonto
    {
        public Sparkonto(string AccountHolderName, int AccountNumber, double AccountBalance) : base(AccountHolderName, AccountNumber, AccountBalance) 
        {
        }

        public override string AccountType()
        {
            return "Sparkonto";
        }
    }
}
