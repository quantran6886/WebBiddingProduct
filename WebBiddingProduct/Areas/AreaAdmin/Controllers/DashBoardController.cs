using Microsoft.AspNetCore.Mvc;

namespace WebBiddingProduct.Areas.AreaAdmin.Controllers
{
    [Area("AreaAdmin")]
    public class DashBoardController : Controller
    {
        public IActionResult DashBoard()
        {
            return View();
        }
    }
}
