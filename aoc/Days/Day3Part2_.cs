using System;

namespace Days
{
    class Day3Part2_
    {
        private static string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static void Part2()
        {   
            int sum = 0;
            string[] group = new string[3];
            int index = 0;
            foreach (string line in System.IO.File.ReadLines(@"Days\inputs\input_3.txt")){
                    group[index%3] = line;
                    index +=1;
                    if(index%3==0 && index > 0){
                        sum += alphabet.IndexOf(intersect(group[0],group[1],group[2]))+1;
                        Array.Clear(group, 0, group.Length);
                    }
            }
            Console.WriteLine(sum);
        }

        private static char intersect(string firstRucksack, string secondRucksack, string thirdRucksack) {
            for(int i = 0; i<firstRucksack.Length; i++){
                if((secondRucksack.IndexOf(firstRucksack[i]) != -1) && (thirdRucksack.IndexOf(firstRucksack[i]) != -1)){
                    return firstRucksack[i];
                }
            }
            throw new InvalidOperationException();
        }
    }
}
