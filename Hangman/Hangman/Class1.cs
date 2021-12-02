using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
  internal class Word
  {
    private string[] _wordlist;
    public Word()
    {
      _wordlist = ReadFile("wordlist.txt");
    }

    public string WordList { get; }

    private string[] ReadFile(string filename)
    {
      try
      {
        using var sr = new StreamReader(filename);
        return sr.ReadToEnd().Split("\n");
      }
      catch (IOException e)
      {
        Console.WriteLine("The file could not be read:");
        Console.WriteLine(e.Message);
        return null;
      }
    }
    
  }
}
