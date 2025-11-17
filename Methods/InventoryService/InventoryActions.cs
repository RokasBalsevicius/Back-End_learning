using Utilities;

namespace INVENTORYMANAGER.Methods
{
    public class InventoryActions
    {
        private readonly Utility utils = new();

        public void AddNewItem(Dictionary<string, List<int>> storage)
        {
            while (true)
            {
                Console.WriteLine("Enter the name of new item or 'Exit' to go back to main menu: ");
                string? newItem = Console.ReadLine()?.Trim().ToUpper();
                if (newItem == "EXIT") break;

                if (storage.ContainsKey(newItem))
                {
                    Console.WriteLine("Item already exists");
                    DisplayItems(storage);
                    continue;
                }

                storage[newItem] = new List<int>();
                Console.WriteLine($"New item '{newItem}' added to storage");

                while (true)
                {
                    Console.WriteLine($"Do you want to also add quantity for new item '{newItem}'? Y - yes, N - no");
                    string? quantityChoice = Console.ReadLine()?.Trim().ToUpper();
                    if (quantityChoice == "Y")
                    {
                        int quantity = utils.ReadNumber<int>("Enter quantity");
                        storage[newItem].Add(quantity);
                        break;
                    }
                    else if (quantityChoice == "N")
                    {
                        Console.WriteLine("Exiting to main menu");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid action selected, try again...");
                    }
                }
                break;
            }
        }

        public void UpdateQuantity(Dictionary<string, List<int>> storage)
        {
            while (true)
            {
                Console.WriteLine("Enter the name of item from the storage you want to update quantity or 'Exit' for main menu: ");
                string? itemName = Console.ReadLine()?.Trim().ToUpper();
                if (itemName == "EXIT") break;

                if (!storage.ContainsKey(itemName))
                {
                    Console.WriteLine("Item does not exist in the storage.");
                    DisplayItems(storage);
                    continue;
                }

                int quantity = utils.ReadNumber<int>($"Enter quantity you want to set for item {itemName}");
                storage[itemName].Clear();
                storage[itemName].Add(quantity);
                Console.WriteLine($"Updated quantity for item '{itemName}' to '{quantity}'");
                break;
            }
        }

        public void RemoveItem(Dictionary<string, List<int>> storage)
        {
            while (true)
            {
                Console.WriteLine("Enter the name of item from the storage you want to remove or 'Exit' for main menu: ");
                string? itemName = Console.ReadLine()?.Trim().ToUpper();
                if (itemName == "EXIT") break;

                if (!storage.ContainsKey(itemName))
                {
                    Console.WriteLine("Item does not exist in the storage.");
                    DisplayItems(storage);
                    continue;
                }

                storage.Remove(itemName);
                Console.WriteLine($"Item '{itemName}' successfully removed.");
                DisplayItems(storage);
                break;
            }
        }

        public void DisplayItems(Dictionary<string, List<int>> storage)
        {
            Console.WriteLine("Currently storage contains the following: ");
            foreach (var item in storage)
            {
                Console.WriteLine($"Item: {item.Key}, quantity: {string.Join(", ", item.Value)}");
            }
        }
    }
}
