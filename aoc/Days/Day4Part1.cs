using System;
using System.Collections.Generic;

namespace Days
{
    class Day4Part1
    {
        public static void Part1()
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
            HashSet<int> t1 = new HashSet<int>(generateArray(int.Parse(firstSec[0]),int.Parse(firstSec[1])));
            HashSet<int> t2 = new HashSet<int>(generateArray(int.Parse(secondSec[0]),int.Parse(secondSec[1])));
            return t2.IsSubsetOf(t1) || t1.IsSubsetOf(t2);
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
