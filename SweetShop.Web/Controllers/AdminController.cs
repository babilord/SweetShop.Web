using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace SweetShop.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        // ✅ نمایش لیست کاربران
        public IActionResult UserList()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        // 🔹 تایید کاربر برای سفارش (ApprovedUser)
        public async Task<IActionResult> ApproveUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.RemoveFromRoleAsync(user, "GuestUser");
                await _userManager.AddToRoleAsync(user, "ApprovedUser");
                TempData["SuccessMessage"] = $"{user.Email} is now approved to order.";
            }

            return RedirectToAction("UserList");
        }

        // 🔹 لغو دسترسی کاربر برای سفارش (بازگشت به GuestUser)
        public async Task<IActionResult> RevokeUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.RemoveFromRoleAsync(user, "ApprovedUser");
                await _userManager.AddToRoleAsync(user, "GuestUser");
                TempData["SuccessMessage"] = $"{user.Email} is now restricted from ordering.";
            }

            return RedirectToAction("UserList");
        }
    }
}
