namespace Packt.Shared
{
    public class BankAccount
    {
        public string AccountName; // instance member
        public decimal Balance; // instance member
        public static decimal InterestRate; // shared member, each instance of BankAccount will have its own Account Name and Balance values, all will share InterestRate
    }
}