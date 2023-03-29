using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using WordPuzzle.Models;

namespace WordPuzzle.Controllers
{
  public class GamesController : Controller
  {
    // [Route("/games")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Index(string userInput)
    {
      System.Diagnostics.Debug.WriteLine("This will be displayed in output window");
      return View("Index");
    }
  }
}