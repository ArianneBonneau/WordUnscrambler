using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace WordUnscrambler
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();

            foreach (var scrambledWord in scrambledWords)
            {
                foreach (var word in wordList)
                {
                    //scrambled word already matches word
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                    }
                    else
                    {
                        //convert strings into char array
                        char[] scrambledWordArray = scrambledWord.ToCharArray();
                        char[] wordArray = word.ToCharArray();

                        //sort both character arrays (Array.sort())
                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordArray);
                        //act -> sort -> act
                        //cat -> sort -> act

                        //compare sorted char arrays or convert to string and compare 
                        string scrambledWord2 = new string(scrambledWordArray);
                        string word2 = new string(wordArray);

                           //if they are equal, add to matchedWords list
                           if (scrambledWord2 == word2)
                           {
                               matchedWords.Add(BuildMatchedWord(scrambledWord2, word2));
                           }
                    }
                }
            }

            MatchedWord BuildMatchedWord(string scrambledWord, string word)
            {
                MatchedWord matchedWord = new MatchedWord
                {
                    ScrambledWord = scrambledWord,
                    Word = word
                };

                return matchedWord;
            }

            return matchedWords;
        }

    }
}
