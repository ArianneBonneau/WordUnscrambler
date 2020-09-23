using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
        private static readonly MatchedWord _matchedWord = new MatchedWord();

        static void Main(string[] args)
        {
            var valid = true;
            while (valid)
            {
                try
                {
                    Console.WriteLine("Enter scrambled word(s) manually or as a file: F - file / M - manual");

                    String option = Console.ReadLine() ?? throw new Exception("String is empty/null");

                    switch (option.ToUpper())
                    {
                        case "F":
                            Console.WriteLine("Enter file path including the file name: ");
                            ExecuteScrambledWordsInFileScenario();
                            break;
                        case "M":
                            Console.WriteLine("Enter word(s) manually (separated by commas if mutiple)");
                            ExecuteScrambledWordManualEntryScenario();
                            break;
                        default:
                            valid = true;
                            Console.WriteLine("The entered option was not recognized");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    //valid = true;
                    Console.WriteLine("The program will be terminated.");
                }

                Console.WriteLine("Would you like to continue? Y/N");
                var answer = Console.ReadLine();
                switch (answer.ToUpper())
                {
                    case "Y":
                        valid = true;
                        break;
                    case "N":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("The entered option was not recognized");
                        valid = true;
                        break;
                }
            }

        }

        private static void ExecuteScrambledWordManualEntryScenario()
        {
            //read user's input - a comma separated string containing scrambled words
            string manualInput = Console.ReadLine();

            //extract words in string [] - use Split()
            char[] separators = { ',', ' ' };
            string[] scrambledWords = manualInput.Split(separators);

            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            //read the user's input - file with scrambled words
            var filename = Console.ReadLine();

            //read words from the file and store in string [] scrambledWords
            string[] scrambledWords = _fileReader.Read(filename);

            //display the matched words
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            //read the list of words in the wordlist.txt file (unscrambled words)
            string[] wordList = _fileReader.Read("wordlist.txt");

            //call a word matcher method, to get a list of MatchedWord structs
            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            //display the match - print to  console

            if (matchedWords.Any())
            {
                //loop through matchWords and print contents of structs
                //foreach

                foreach (var matchedWord in matchedWords)
                {
                    //write to console
                    //MATCH FOUND FOR act: cat
                    Console.WriteLine("MATCH FOUND FOR {0}: {1}", _matchedWord.GetScrambledWord() , _matchedWord.GetWord());
                }
            }
            else
            {
                //NO MATCHES HAVE BEEN FOUND
                Console.WriteLine("NO MATCHES HAVE BEEN FOUND");
            }
        }
    }



}

