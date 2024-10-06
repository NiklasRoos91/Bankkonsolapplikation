namespace BankkonsolapplikationW2
{
    public class Bankkonto
    {
        public string accountHolderName { get; set; }
        public int accountNumber { get; set; }
        public double accountBalance { get; set; }

        public Bankkonto(string AccountHolderName, int AccountNumber, double AccountBalance)
        {
            accountHolderName = AccountHolderName;
            accountNumber = AccountNumber;
            accountBalance = AccountBalance;

        }

        // metoder för att ta ut, sätta in, kolla saldo och överföra pengar
        public void Withdraw()
        {
            int moneyToWithdraw;
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Hur mycket vill du ta ut");
                string input = Console.ReadLine()!;

                if (ContainsOnlyNumbers(input))
                {
                    moneyToWithdraw = Convert.ToInt32(input);

                    if (moneyToWithdraw <= accountBalance)
                    {
                        accountBalance -= moneyToWithdraw;
                        Console.WriteLine($"Du har tagit ut {moneyToWithdraw}, nytt saldo på {this.AccountType()} : {accountBalance}");

                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Du kan inte ta ut den summan, du har inte tillräckligt på kontot");
                    }
                }
                else
                {
                    Console.WriteLine("Felaktig inmatning. Vänligen ange endast siffror.");
                }
            }
        }

        public void Deposit()
        {
            int moneyToDeposit;
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Hur mycket vill du sätta in");

                string input = Console.ReadLine()!;

                if (ContainsOnlyNumbers(input))
                {
                    moneyToDeposit = Convert.ToInt32(input);

                    accountBalance += moneyToDeposit;

                    Console.WriteLine($"Du satte in {moneyToDeposit}, nytt saldo på {this.AccountType()} : {accountBalance}");

                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Felaktig inmatning. Vänligen ange endast siffror.");
                }
            }
        }

        public void CheckBalance()
        {
            Console.WriteLine($"Du har {accountBalance} på {this.AccountType()}");
        }

        public virtual void TransferMoney(Bankkonto targetAccount)
        {
            int moneyToTransfer;
            bool validInput = false;

            while (!validInput)
            {
                Console.Write("Skriv hur mycket du vill förra över : ");
                string input = Console.ReadLine()!;

                if (ContainsOnlyNumbers(input))
                {
                    moneyToTransfer = Convert.ToInt32(input);

                    if (moneyToTransfer <= accountBalance)
                    {
                        accountBalance -= moneyToTransfer;

                        targetAccount.accountBalance += moneyToTransfer;

                        Console.WriteLine($"Överfört {moneyToTransfer} från {this.AccountType()} till {targetAccount.AccountType()}. Nytt saldo på {this.AccountType()} : {accountBalance}.");

                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Otillräckligt med pengar på konto för att förra över");
                    }
                }
                else
                {
                    Console.WriteLine("Felaktig inmatning. Vänligen ange endast siffror.");
                }
            }
        }

        public virtual string AccountType()
        {
            return "Bankkonto";
        }

        public bool ContainsOnlyNumbers(string input)
        {
            foreach (char character in input)
            {
                if (!char.IsDigit(character))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
