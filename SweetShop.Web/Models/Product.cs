using System.ComponentModel.DataAnnotations;

namespace SweetShop.Web.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Range(0, 100000)]
        public decimal Price { get; set; }

        public string? ImagePath { get; set; } // مسیر ذخیره عکس
    }
}
