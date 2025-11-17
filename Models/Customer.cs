namespace BANKING.Models;

public class Customer
{
    public string FullName { get; set; }
    public long PersonalNumber { get; set; }
    public List<Account> Accounts { get; set; } = new();
}