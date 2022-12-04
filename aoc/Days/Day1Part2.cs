using System;
using System.Collections;  

namespace Days
{
    class Day1Part2
    {
        public static void Part2()
        {
            int itemSum = 0;
            var itemList = new ArrayList(); 
            foreach (string line in System.IO.File.ReadLines(@"Days\inputs\input.txt"))
            {  
                if(line == ""){
                    itemList.Add(itemSum);
                    itemSum = 0;
                }  
                else{
                    itemSum += int.Parse(line);
                }
            }
            itemList.Sort();

            int topThreeElves = 0;
            for(int i = itemList.Count-1; i>itemList.Count-4; i--){
                topThreeElves += (int)itemList[i];
            }
            Console.WriteLine(topThreeElves);
        }
    }
}
