using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SweetShop.Web.Areas.Admin.Models
{
    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "Please enter the product name")]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required(ErrorMessage = "Please enter the unit price")]
        [Range(0.01, 10000)]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Please enter stock quantity")]
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        public IFormFile? ImageFile { get; set; }
    }
}
