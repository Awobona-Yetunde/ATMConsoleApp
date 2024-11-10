using System;
using System.Net.NetworkInformation;

public class cardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }
    public string getFirstName()
    {
        return firstName;
    }
    public string getLastName()
    {
        return lastName;
    }
    public double getBalance()
    {
        return balance;
    }

    public void setNum(string newCardNum)
    {
        cardNum = newCardNum;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }
    public void setLastName(string newLastName)
    {
        firstName = newLastName;
    }
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check balance");
            Console.WriteLine("4. Exit");
        }
        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your money. Your new balance is " + currentUser.getBalance());
        }
        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw? ");
            double withdrawal = Double.Parse(Console.ReadLine());
            if (withdrawal > currentUser.getBalance())
            {
                Console.WriteLine("Insufficient funds");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You're good to go. Thank you!");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Your account balance is " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("45327728185227395", 1234, "Micheal", "Sunday", 171.13));
        cardHolders.Add(new cardHolder("45327728185227385", 4321, "Adedoyin", "Femi", 105.59));
        cardHolders.Add(new cardHolder("45327728185227375", 9999, "Victor", "Attah", 251.84));
        cardHolders.Add(new cardHolder("45327728185227365", 2466, "olivia", "Johnson", 54.27));
        cardHolders.Add(new cardHolder("45327728185227323", 4826, "Yetunde", "Awobona", 950.31));

        Console.WriteLine("Welcome to the ATM");
        Console.WriteLine("Enter your pin");
        int userPin = 0;
        cardHolder currentUser;

        while (true)
        {
            try
            {
                userPin = Convert.ToInt32(Console.ReadLine());
                currentUser = cardHolders.FirstOrDefault(a => a.getPin() == userPin);
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect pin! Please try again.");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect pin! Please try again.");
            }
        }
        Console.WriteLine("Welcome " + currentUser.getFirstName());
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = Convert.ToInt32(Console.ReadLine());
                if (option == 1) { deposit(currentUser); }
                else if (option == 2) { withdraw(currentUser); }
                else if (option == 3) { balance(currentUser); }
                else if (option == 4) { break; }
                else { option = 0; }
            }
            catch
            {
                Console.WriteLine("Please choose from the options 1 - 4");
            }

        } while (option != 4);
        Console.WriteLine("Thank you! Please take your card.");

    }


}
