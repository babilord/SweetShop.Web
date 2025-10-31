// InventoryItem.cs
namespace SweetShop.Domain.Entities
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Quantity { get; set; }
        public string Unit { get; set; } = "kg";
        public string Type { get; set; } = "RawMaterial"; // or ReadyProduct
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}
