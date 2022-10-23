using Microsoft.AspNetCore.Mvc;

namespace CandyShop.Controllers
{
    public class HomeController : Controller
    {
      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }
    }
}