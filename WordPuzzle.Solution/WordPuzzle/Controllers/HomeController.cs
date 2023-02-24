using Microsoft.AspNetCore.Mvc;

namespace WordPuzzle.Controllers
{
  public class HomeController : Controllers
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}