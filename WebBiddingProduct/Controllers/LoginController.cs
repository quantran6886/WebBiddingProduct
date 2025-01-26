using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebBiddingProduct.Areas.AreaAdmin.Models;

namespace WebBiddingProduct.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public LoginController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Login(string data)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                //    var user = await _userManager.FindByNameAsync(model.UserName);
                //    if (user != null)
                //    {
                //        var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, false);

                //        if (result.Succeeded)
                //        {
                //            return Json(new { success = 200, message = "SUCCESS",email = user.Email});
                //        }
                //        else
                //        {
                //            return Json(new { success = false, message = "Sai mật khẩu." });
                //        }
                //    }
                //    else
                //    {
                //        return Json(new { success = false, message = "Tài khoản không tồn tại." });
                //    }
                //}
                //else
                //{
                //    return Json(new { success = false, message = "Dữ liệu không hợp lệ." });
                //}
                return Json(new { success = 200, message = "SUCCESS"/*, email = user.Email */});
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Đã xảy ra lỗi.", error = ex.Message });
            }
        }
    }
}
