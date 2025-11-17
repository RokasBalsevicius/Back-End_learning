namespace INVENTORYMANAGER.Repositories
{
    public class InventoryRepository
    {
        public Dictionary<string, List<int>> Storage { get; set; }

        public InventoryRepository()
        {
            Storage = new Dictionary<string, List<int>>
            {
                {"MESA", new List<int>()},
                {"POMIDORAI", new List<int>()}
            };
        }
    }
}