﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WordUnscrambler
{       
        /// <summary>
        /// Arianne Bonneau
        /// </summary>
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
                    var valid1 = false;
                    while (!valid1)
                    {

                        Console.WriteLine(Constants.FirstQuestion);

                        String option = Console.ReadLine() ?? throw new Exception(Constants.Null);

                        switch (option.ToUpper())
                        {
                            case "F":
                                valid1 = true;
                                Console.WriteLine(Constants.FileName);
                                ExecuteScrambledWordsInFileScenario();
                                break;
                            case "M":
                                valid1 = true;
                                Console.WriteLine(Constants.ManualWord);
                                ExecuteScrambledWordManualEntryScenario();
                                break;
                            default:
                                valid1 = false;
                                Console.WriteLine(Constants.OptionNotFound);
                            break;
                        }
                    }

                    var valid2 = false;
                    while (!valid2)
                    {
                        Console.WriteLine(Constants.Continue);
                        var answer = Console.ReadLine();
                        switch (answer.ToUpper())
                        {
                            case "Y":
                                valid2 = true;
                                break;
                            case "N":
                                valid2 = true;
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine(Constants.OptionNotFound);
                                valid2 = false;
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //valid = true;
                    Console.WriteLine(Constants.Terminate);
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
            try
            {
                string[] scrambledWords = _fileReader.Read(filename);
                //display the matched words
                DisplayMatchedUnscrambledWords(scrambledWords);
            }
            catch (Exception ex)
            {
                //valid = true;
                Console.WriteLine(Constants.FileError);
            }
       
        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            //read the list of words in the wordlist.txt file (unscrambled words)
            string[] wordList = _fileReader.Read("wordlist.txt");

            //call a word matcher method, to get a list of MatchedWord structs
            List<MatchedWord> matchedWords = new List<MatchedWord>();
            matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            //display the match - print to  console

            if (matchedWords.Any())  
            {
                //loop through matchWords and print contents of structs
                //foreach

                foreach (var matchedWord in matchedWords)
                {
                    //write to console
                    //MATCH FOUND FOR act: cat
                    Console.WriteLine("MATCH FOUND FOR {0}: {1}", matchedWord.GetScrambledWord().ToString(), matchedWord.GetWord().ToString());
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

