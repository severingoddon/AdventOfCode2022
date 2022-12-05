using System;

namespace Days
{
    class Day3Part1
    {
        private static string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static void Part1()
        {   
            int sum = 0;
            foreach (string line in System.IO.File.ReadLines("./Days/inputs/input_3.txt")){
                    sum += alphabet.IndexOf(intersect(line.Substring(0, line.Length/2), line.Substring(line.Length/2, line.Length/2)))+1;
            }
            Console.WriteLine(sum);
        }

        private static char intersect(string firstCompartement, string secondCompartement) {
            for(int i = 0; i<firstCompartement.Length; i++){
                if(secondCompartement.IndexOf(firstCompartement[i]) != -1){
                    return firstCompartement[i];
                }
            }
            throw new InvalidOperationException();
        }
    }
}
