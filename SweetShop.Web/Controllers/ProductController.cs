using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SweetShop.Web.Controllers
{
    public class ProductController : Controller
    {
        // 👀 همه می‌تونن لیست محصولات رو ببینن
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        // 🛒 فقط کاربران ApprovedUser یا Admin می‌تونن سفارش بدن
        [Authorize(Roles = "ApprovedUser,Admin")]
        public IActionResult Order()
        {
            return View();
        }
    }
}
