using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    struct MatchedWord
    {
        public string ScrambledWord;
        
        public string GetScrambledWord()
        {
            return ScrambledWord;
        }

        public void SetScrambledWord(string ScrambledWord)
        {
            this.ScrambledWord = ScrambledWord;
        }

        public string Word;

        public string GetWord()
        {
            return Word;
        }

        public void SetWord(string Word)
        {
            this.Word = Word;
        }
    }
}
