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
      return View();
    }
  }
}