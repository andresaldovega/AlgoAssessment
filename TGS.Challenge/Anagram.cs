namespace TGS.Challenge
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    /*
        Devise a function that checks if 1 word is an anagram of another, if the words are anagrams of
        one another return true, else return false

        "Anagram": An anagram is a type of word play, the result of rearranging the letters of a word or
        phrase to produce a new word or phrase, using all the original letters exactly once; for example
        orchestra can be rearranged into carthorse.

        areAnagrams("horse", "shore") should return true
        areAnagrams("horse", "short") should return false

        NOTE: Punctuation, including spaces should be ignored, e.g.

        horse!! shore = true
        horse  !! shore = true
          horse? heroes = true

        There are accompanying unit tests for this exercise, ensure all tests pass & make
        sure the unit tests are correct too.
     */
    public class Anagram
    {
      public bool AreAnagrams(string word1, string word2)
      {
          const string charsToIgnore = "[@,\\.!?_ ']";

          if (string.IsNullOrWhiteSpace(word1))
          {
                throw new ArgumentException(nameof(word1));
          }

          if (string.IsNullOrWhiteSpace(word2))
          {
              throw new ArgumentException(nameof(word2));
          }

          var cleanedWord1 = Regex.Replace(word1, charsToIgnore, string.Empty).ToLower();
          var cleanedWord2 = Regex.Replace(word2, charsToIgnore, string.Empty).ToLower();

          var word1CharArray = cleanedWord1.ToCharArray();
          var word2CharArray = cleanedWord2.ToCharArray();

          Array.Sort(word1CharArray);
          Array.Sort(word2CharArray);

          return word1CharArray.SequenceEqual(word2CharArray);
      }
    }
}
