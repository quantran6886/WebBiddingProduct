using Microsoft.AspNetCore.Mvc;

namespace WebBiddingProduct.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }
    }
}
