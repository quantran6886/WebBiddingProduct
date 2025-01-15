using Microsoft.AspNetCore.Mvc;

namespace WebBiddingProduct.Controllers
{
    public class ListViewProductsController : Controller
    {
        public IActionResult ListViewProducts()
        {
            return View();
        }
    }
}
