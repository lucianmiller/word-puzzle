using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using WordPuzzle.Models;

namespace WordPuzzle.Controllers
{
  public class GamesController : Controller
  {
    [Route("/games")]
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Game(string userInput)
    {
      Game newGame = new Game();
      newGame.UserInput = userInput;
      return View(newGame);
    }
  }
}