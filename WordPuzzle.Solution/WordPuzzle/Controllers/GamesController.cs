using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using WordPuzzle.Models;

namespace WordPuzzle.Controllers
{
  public class GamesController : Controller
  {
    [HttpGet("/games")]
    public ActionResult Index()
    {
      if (Game.Instance == null)
      {
        Game newGame = new Game();
        newGame.GameStart();
      }
      return View(Game.Instance);
    }

    [HttpPost]
    public ActionResult Index(string userInput)
    {
      if (char.TryParse(userInput, out char c))
      {
        Game.Instance.MakeGuess(Char.ToLower(c));
      }
      if (Game.Instance.Win || Game.Instance.Lose)
      {
        return View("GameOver", Game.Instance);
      }
      return View("Index", Game.Instance);
    }

    [HttpGet ("/games/gameover")]
    public ActionResult GameOver()
    {
      return View();
    }

    [HttpPost("/games/reset")]
    public ActionResult ResetGame()
    {
      Game.Instance.ResetGame();
      return RedirectToAction("Index");
    }
  }
}