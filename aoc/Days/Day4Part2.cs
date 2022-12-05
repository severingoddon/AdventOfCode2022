using System;
using System.Linq;

namespace Days
{
    class Day4Part2
    {
        public static void Part2()
        {   
            int count = 0; 
            foreach (string line in System.IO.File.ReadLines("./Days/inputs/input_4.txt")){
                string[] splitted = line.Split(",");
                string firstSection = splitted[0];
                string secondSection = splitted[1];
                if(checkIfSubset(firstSection, secondSection)){
                    count++;
                }
            }
            Console.WriteLine(count);
        }

        private static bool checkIfSubset(string firstSection, string secondSection){
            string[] firstSec = firstSection.Split("-");
            string[] secondSec = secondSection.Split("-");
            var intersect = generateArray(int.Parse(firstSec[0]),int.Parse(firstSec[1])).Intersect(generateArray(int.Parse(secondSec[0]),int.Parse(secondSec[1])));
            return !(intersect.Count() == 0);
        }

        private static int[] generateArray(int firstIndex, int secondIndex){
            int[] arr = new int[secondIndex-firstIndex+1];
            int count = 0;
            for(int i = firstIndex; i<=secondIndex; i++){
                arr[count] = i;
                count++;
            }
            return arr;
        }
    }
}
