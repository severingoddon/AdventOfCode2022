using System; 
using System.Text.RegularExpressions;

namespace Days
{
    class Day2Part1
    {
        private static readonly Regex sWhitespace = new Regex(@"\s+");
        public static void Part1()
        {
            int score = 0; 
            foreach (string line in System.IO.File.ReadLines(@"Days\inputs\input_2.txt"))
            {  
                score += calculateRoundScore(sWhitespace.Replace(line, ""));  
            }
            Console.WriteLine(score);
        }

        private static int calculateRoundScore(string input){
            switch(input){
                case "AX":
                    return 4;
                case "AY":
                    return 8;
                case "AZ":
                    return 3;
                case "BX":
                    return 1;
                case "BY":
                    return 5;
                case "BZ":
                    return 9;
                case "CX":
                    return 7;
                case "CY":
                    return 2;
                case "CZ":
                    return 6;
                default:
                    return 0;
            }
        }
    }
}
