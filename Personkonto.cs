namespace BankkonsolapplikationW2
{
    public class Personkonto : Bankkonto
    {
        public Personkonto(string AccountHolderName, int AccountNumber, double AccountBalance) : base(AccountHolderName, AccountNumber, AccountBalance)
        {
        }

        public override string AccountType()
        {
            return "Personkonto";
        }
    }
}
