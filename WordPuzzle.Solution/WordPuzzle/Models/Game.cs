using System.Collections.Generic;
using System;
using System.Linq;

namespace WordPuzzle.Models
{
  public class Game
  {
    public static Game Instance { get; set; }
    public string UserInput { get; set; }
    public string Word { get; set; }
    public bool Win { get; set; }
    public bool Lose { get; set; }
    public List<Char> CharList { get; set; } = new List<Char>();
    public List<Char> EmptyList { get; set; } = new List<Char>();
    public List<Char> CorrectList { get; set; } = new List<Char>();
    public List<Char> IncorrectList { get; set; } = new List<Char>();

    public Game()
    {
      if (Instance == null) {
        Instance = this;
      }
    }

    public void GameStart()
    {
      Random random = new Random();
      List<String> wordDictionary = new List<String> {"asteroid", "astronaut", "astronomer", "atmosphere", "comet", "constellation", "corona", "cosmos", "crater", "eclipse", "equinox", "force", "galaxy", "gravity", "hemisphere", "meteor", "meteorite", "moon", "nebula", "observatory", "orbit", "planet", "pulsar", "quasar", "space", "star", "sun", "universe"};
      int index = random.Next(wordDictionary.Count);
      String randomWord = wordDictionary[index];
      Word = randomWord;
      CharList.AddRange(Word);
      foreach (char c in CharList)
      {
        EmptyList.Add('_');
      }
    }

    public void MakeGuess(char guess)
    {
      if (Char.IsLetter(guess))
      {
        if (Word.Contains(guess)) 
        {
          CorrectList.Add(guess);
          AddCorrectGuess(guess);
        }
        else
        {
          IncorrectList.Add(guess);
        }
        EndGameCheck();
      }
      else
      {
        Console.WriteLine("Please guess a letter");
      }
    }

    private void AddCorrectGuess(char correctGuess)
    {
      for (int index = 0; index < CharList.Count; index++) 
      {
        if (correctGuess == CharList[index])
        {
          EmptyList[index] = correctGuess;
        }
      }
    }

    private void EndGameCheck()
    {
      if (IncorrectList.Count >= 6)
      {
        Lose = true;
      }
      else if (!EmptyList.Contains('_'))
      {
        Win = true;
      }
    }

    public void ResetGame()
    {
      Instance = null;
      Win = false;
      Lose = false;
      CharList = new List<Char>();
      EmptyList = new List<Char>();
      CorrectList = new List<Char>();
      IncorrectList = new List<Char>();
    }
  }
}