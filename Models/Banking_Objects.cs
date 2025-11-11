namespace BankingAppObjects;

public class Account
{
    public String Type { get; set; }
    public double Balance { get; set; }
}

public class Customer
{
    public String FullName { get; set; }
    public long PersonalNumber { get; set; }
    public List<Account> Accounts { get; set; } = new();
}