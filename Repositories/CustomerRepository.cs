using BANKING.Models;

namespace BANKING.Repositories;

public class CustomerRepository
{
    public List<Customer> Customers { get; set; } = new()
    {

        new Customer
        {
            FullName = "ROKAS BALSEVICIUS",
            PersonalNumber = 123456789,
            Accounts =
            {
                new() {Type = "CHECKINGS", Balance = 1000 },
                new() {Type = "SAVINGS", Balance = 1400.34}
            }
        },
        new Customer
        {
            FullName = "EMA KURMILEVICIUTE",
            PersonalNumber = 123456089,
            Accounts =
            {
                new() { Type = "CHECKINGS", Balance = 2345.45},
                new() { Type = "SAVINGS", Balance = 20000.44}
            }
        }
    };
}

