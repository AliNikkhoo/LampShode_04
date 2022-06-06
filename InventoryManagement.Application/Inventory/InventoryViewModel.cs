namespace InventoryManagement.Application.Inventory
{
    public class InventoryViewModel
    {
        public long Id { get; set; }
        public string Product { get; set; }
        public double UnintPrice { get; set; }
        public long productId { get; set; }
        public bool InStock { get; set; }
        public long CurrentCount { get; set; }
        public string CreationDate { get; set; }
    }
}
