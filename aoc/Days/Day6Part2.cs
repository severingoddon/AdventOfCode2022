using System;
using System.Collections.Generic;

namespace Days
{
    class Day6Part2
    {
        public static void Part2()
        {
            HashSet<string> data = new HashSet<string>();
            foreach (string line in System.IO.File.ReadLines("./Days/inputs/input_6.txt")){
                for(int i = 0; i<line.Length; i++){
                    if(i>13){
                        if(check(line.Substring(i-13, 14))){
                            Console.WriteLine(i+1);
                            break;
                        }
                    }
                }
            }
        }
        private static bool check(string sub){
            HashSet<char> letters = new HashSet<char>();
            foreach(char c in sub){
                letters.Add(c);
            }
            return(letters.Count == 14);
        }
    }
}
