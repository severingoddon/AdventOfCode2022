using System;
using System.Collections;  

namespace Days
{
    class Day1Part1
    {
        public static void Part1()
        {
            int itemSum = 0;
            var elvesList = new ArrayList(); 
            foreach (string line in System.IO.File.ReadLines(@"Days\inputs\input.txt"))
            {  
                if(line == ""){
                    elvesList.Add(itemSum);
                    itemSum = 0;
                }  
                else{
                    itemSum += int.Parse(line);
                }
            }
            elvesList.Sort();
            
            Console.WriteLine(elvesList[elvesList.Count-1]);
        }
    }
}
