using Microsoft.AspNetCore.Mvc;

namespace WebBiddingProduct.Areas.AreaAdmin.Controllers
{
    [Area("AreaAdmin")]
    public class ProfileController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }
    }
}
