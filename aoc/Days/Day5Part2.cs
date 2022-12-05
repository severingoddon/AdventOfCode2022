using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace Days
{
    class Day5Part2
    {
        private static Stack[] stacks = new Stack[9];
        public static void Part2()
        {
            buildStacks();
            foreach (string line in System.IO.File.ReadLines("./Days/inputs/input_5_2.txt")){
                string move = Regex.Replace(line, "[A-Za-z]", "");
                string[] splitted = move.Split("  ");
                moveStacks(int.Parse(splitted[0]), int.Parse(splitted[1]), int.Parse(splitted[2]));
            }

            String result = "";
            for(int i = 0; i<stacks.Length; i++){
                result += stacks[i].Pop();
            }
            Console.WriteLine(result);
        }

        public static void moveStacks(int count, int sourceStack, int targetStack){
            string[] sourceStackElements = new string[count];
            for(int i = 0; i<count; i++){
                sourceStackElements[i] = (string)stacks[sourceStack-1].Pop();

            }
            for(int i = sourceStackElements.Length-1; i>=0; i--){
                stacks[targetStack-1].Push(sourceStackElements[i]);
            }
        }

        public static void buildStacks() {
            for(int i = 0; i<9; i++){
                Stack stack = new Stack();
                stacks[i] = stack;
            }
            foreach (string line in System.IO.File.ReadLines("./Days/inputs/input_5.txt")){
                int count = 1;
                for(int i = 0; i<line.Length; i++){
                    if(i%4==1){
                        if(Char.ToString(line[i])!=" "){
                            stacks[count-1].Push(Char.ToString(line[i]));
                        }
                        count++;
                    }
                }
                if(line == ""){
                    break;
                }
            }
            for(int i = 0; i<stacks.Length; i++){
                stacks[i] = Reverse(stacks[i]);
            }
        }

        public static Stack Reverse(Stack input)
        {
            Stack temp = new Stack();
            while (input.Count != 0){
                temp.Push(input.Pop());
            }
            return temp;
        }
    }
}
