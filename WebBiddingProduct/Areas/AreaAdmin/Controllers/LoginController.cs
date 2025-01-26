using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebBiddingProduct.Areas.AreaAdmin.Data;
using WebBiddingProduct.Areas.AreaAdmin.Models;

namespace WebBiddingProduct.Areas.AreaAdmin.Controllers
{
    [Area("AreaAdmin")]
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
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByNameAsync(model.UserName);
                    if (user != null)
                    {
                        var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, false);

                        if (result.Succeeded)
                        {
                            return RedirectToAction("DashBoard", "DashBoard");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    }
                }
                Console.WriteLine("PasswordHash is valid Base64.");
            }
            catch (Exception ex)
            {
                string messages = ex.Message;
                Console.WriteLine("PasswordHash is not valid Base64.");
            }
            

            return View(model);
        }
    }
}
