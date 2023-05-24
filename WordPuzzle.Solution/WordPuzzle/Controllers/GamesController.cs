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
        System.Console.WriteLine("-----------");
        System.Console.WriteLine(newGame.Word);
        System.Console.WriteLine(String.Join(" ", newGame.CharList));
        System.Console.WriteLine(String.Join(" ", newGame.EmptyList));
        System.Console.WriteLine("-----------");
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
      System.Console.WriteLine("-----------");
      System.Console.WriteLine("Correct: " + String.Join(" ", Game.Instance.CorrectList));
      System.Console.WriteLine("Incorrect: " + String.Join(" ", Game.Instance.IncorrectList));
      System.Console.WriteLine(String.Join(" ", Game.Instance.EmptyList));
      System.Console.WriteLine("-----------");
      if (Game.Instance.Win || Game.Instance.Lose)
      {
        Console.WriteLine("Game Over!");
        return View("GameOver", Game.Instance);
        // if (Game.Instance.Win)
        // {
        //   Console.WriteLine("You Win!");
        // }
        // else
        // {
        //   Console.WriteLine("You Lose!");
        // }
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