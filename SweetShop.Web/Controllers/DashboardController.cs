using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SweetShop.Web.Controllers
{
    [Authorize] // ⛔ فقط کاربران لاگین‌شده اجازه دارند
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
