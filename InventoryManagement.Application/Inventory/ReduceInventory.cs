namespace InventoryManagement.Application.Inventory
{
    public class ReduceInventory
    {
        public long InventoryId { get; set; }
        public long ProudctId { get; set; }
        public long Count { get; set; }
        public string Description { get; set; }
        public long OrderId { get; set; }
    }
}
