namespace BankkonsolapplikationW2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till ditt bankonto");

            Personkonto personkontoPelle = new Personkonto("Pelle", 98298, 10000);

            Sparkonto sparkontoPelle = new Sparkonto("Pelle", 83782, 2000);

            Investeringskonto investeringskontoPelle = new Investeringskonto("Pelle", 34989, 20000);

            User user = new User(personkontoPelle, sparkontoPelle, investeringskontoPelle);

            while (true)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("Välj Konto :");
                Console.WriteLine("-----------------------");
                Console.WriteLine("1 - Personkonto");
                Console.WriteLine("2 - Sparkonto");
                Console.WriteLine("3 - Investeringskonto");
                Console.WriteLine("4 - Avsluta");
                Console.WriteLine("-----------------------");

                int chooseAccount = 0;
                bool validInput = false;

                while (!validInput)
                {
                    string input = Console.ReadLine()!;

                    if (personkontoPelle.ContainsOnlyNumbers(input))
                    {
                        chooseAccount = Convert.ToInt32(input);

                        if (chooseAccount >= 1 && chooseAccount <= 4)
                        {
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Felaktigt val, vänligen ange ett nummer mellan 1 och 4.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Felaktig inmatning. Vänligen ange endast siffror.");
                    }
                }

                // Variabel för att hålla det valda kontot
                dynamic selectedAccount = null;

                switch (chooseAccount)
                {
                    case 1:
                        selectedAccount = personkontoPelle;
                        Console.WriteLine("Personkonto");
                        break;
                    case 2:
                        selectedAccount = sparkontoPelle;
                        Console.WriteLine("Sparkonto");
                        break;
                    case 3:
                        selectedAccount = investeringskontoPelle;
                        Console.WriteLine("Investeringskonto");
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Felaktigt val");
                        break;
                }

                // Om ett konto har valts, kalla på åtgärdsmetoden
                if (selectedAccount != null)
                {
                    AccountMenu(selectedAccount, user); // Kalla metoden med det valda kontot
                }
            }

        }

        private static void AccountMenu(dynamic selectedAccount, User user)
        {
            while (true)
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine($"Du är på: {selectedAccount.AccountType()}");
                Console.WriteLine("Välj vad du vill göra : ");
                Console.WriteLine("1 - Kolla saldo");
                Console.WriteLine("2 - Sätta in");
                Console.WriteLine("3 - Ta ut");
                Console.WriteLine("4 - Överföring");
                Console.WriteLine("5 - Avsluta");
                Console.WriteLine("-----------------------");

                int chooseOption = 0;
                bool validInput = false;

                while (!validInput)
                {
                    string input = Console.ReadLine()!;

                    if (selectedAccount.ContainsOnlyNumbers(input))
                    {
                        chooseOption = Convert.ToInt32(input);

                        if (chooseOption >= 1 && chooseOption <= 5)
                        {
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Felaktigt val, vänligen ange ett nummer mellan 1 och 5.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Felaktig inmatning. Vänligen ange endast siffror.");
                    }

                    switch (chooseOption)
                    {
                        case 1:

                            selectedAccount.CheckBalance();
                            break;
                        case 2:
                            selectedAccount.Deposit();
                            break;
                        case 3:
                            selectedAccount.Withdraw();
                            break;
                        case 4:

                            int targetAccountNumber = 0;
                            bool validAccountInput = false;

                            while (!validAccountInput)
                            {
                                Console.WriteLine("Ange kontonummer för mottagande konto:");
                                input = Console.ReadLine()!;

                                if (selectedAccount.ContainsOnlyNumbers(input))
                                {
                                    targetAccountNumber = Convert.ToInt32(input);
                                    Bankkonto targetAccount = GetTargetAccount(targetAccountNumber, user);
                                    if (targetAccount != null)
                                    {
                                        selectedAccount.TransferMoney(targetAccount);
                                        validAccountInput = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Det angivna kontot hittades inte.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Det angivna kontot hittades inte. Försök igen.");
                                }
                            }
                            break;
                        case 5:
                            Console.WriteLine("Tillbaka till kontovalsmenyn.");
                            return;
                        default:
                            Console.WriteLine("Felaktigt val, försök igen.");
                            continue;
                    }
                }
            }
        }
        private static Bankkonto GetTargetAccount(int AccountNumber, User user)
        {
            // Returnera det konto som matchar det angivna kontonumret
            if (AccountNumber == user.personKonto.accountNumber)
                return user.personKonto;
            else if (AccountNumber == user.sparKonto.accountNumber)
                return user.sparKonto;
            else if (AccountNumber == user.investeringsKonto.accountNumber)
                return user.investeringsKonto;
            else
                return null; // Konto hittades inte
        }
    }
}