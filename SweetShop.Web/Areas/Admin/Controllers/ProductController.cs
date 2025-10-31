using Microsoft.AspNetCore.Mvc;
using SweetShop.Infrastructure;
using SweetShop.Domain.Entities;
using SweetShop.Web.Areas.Admin.Models;

namespace SweetShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateProductViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            string? imagePath = null;

            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                var uploadsRoot = Path.Combine(_env.WebRootPath, "uploads");
                if (!Directory.Exists(uploadsRoot))
                    Directory.CreateDirectory(uploadsRoot);

                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(model.ImageFile.FileName)}";
                var filePath = Path.Combine(uploadsRoot, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageFile.CopyTo(stream);
                }

                imagePath = $"/uploads/{fileName}";
            }

            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                UnitPrice = model.UnitPrice,
                StockQuantity = model.StockQuantity,
                ImagePath = imagePath,
                IsActive = true,
                CreatedAt = DateTime.Now
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
