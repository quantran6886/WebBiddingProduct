using Microsoft.AspNetCore.Mvc;

namespace WebBiddingProduct.Controllers
{
    public class IntroductionController : Controller
    {
        public IActionResult Introduction()
        {
            return View();
        }
    }
}
