using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Random;
using WordPuzzle.Models;

namespace WordPuzzle.Controllers
{
  public class GameController : Controller
  {
    [HttpGet('place holder')]
    public ActionResult New(aaaaaaaaaaaaa)
    {
      Random random = new Random();
      List<String> wordDictionary = new List<String> {"asteroid", "astronaut", "astronomer", "atmosphere", "comet", "constellation", "corona", "cosmos", "crater", "eclipse", "equinox", "force", "galaxy", "gravity", "hemisphere", "meteor", "meteorite", "moon", "nebula", "observatory", "orbit", "planet", "pulsar", "quasar", "space", "star", "sun", "universe"};
      int index = random.Next(wordDictionary.Count);
      String randomWord = wordDictionary[index];
    }
  }
}