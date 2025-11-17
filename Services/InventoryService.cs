using Utilities;
using INVENTORYMANAGER.Methods;
using INVENTORYMANAGER.Repositories;

namespace INVENTORYMANAGER.Services
{



    public class InventoryService
    {
        private readonly Utility utils = new();
        private readonly InventoryActions actions = new();
        private readonly InventoryRepository repository = new();

        public void ManageInventory()
        {
            var storage = repository.Storage;
            
            while (true)
            {
                Console.WriteLine("Inventory Management MENU: ");
                Console.WriteLine("1 - Add new item");
                Console.WriteLine("2 - Update quantity");
                Console.WriteLine("3 - Remove item");
                Console.WriteLine("4 - Display all items");
                Console.WriteLine("5 - Exit");

                int menuOption = utils.ReadNumber<int>("Enter menu option: ");

                switch (menuOption)
                {
                    case 1:
                        actions.AddNewItem(storage);
                        continue;
                    case 2:
                        actions.UpdateQuantity(storage);
                        continue;
                    case 3:
                        actions.RemoveItem(storage);
                        continue;
                    case 4:
                        actions.DisplayItems(storage);
                        continue;
                    case 5:
                        Console.WriteLine("Exiting inventory program... Bye!");
                        return;
                    default:
                        Console.WriteLine("Invalid menu option selected!");
                        continue;
                }
            }
        }
    }
}