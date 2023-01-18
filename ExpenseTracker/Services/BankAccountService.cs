namespace ExpenseTracker.Services
{
    /// <summary>
    /// Test class - för testing uppgift - ta bort sen
    /// </summary>
    public enum BankAccountStatus
    {
        Ok,
        NotEnoughBalance,
        AmountTooBig

    }
    public class BankAccount
    {
        public string AccountNo { get; set; } = string.Empty;
        public int Balance { get; set; }


        public BankAccountStatus Withdrawal(int amount)
        {
            if (Balance < 3000) return BankAccountStatus.AmountTooBig;
            if (Balance < amount) return BankAccountStatus.NotEnoughBalance;
            Balance = Balance - amount;
            return BankAccountStatus.Ok;
        }

        public BankAccountStatus Deposit(int amount)
        {
            Balance = Balance + amount;
            return BankAccountStatus.Ok;
        }

    }
}
