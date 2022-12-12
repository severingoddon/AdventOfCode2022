using System;
using System.Collections;  

namespace Days
{
    class Day8Part1
    {
        ArrayList grid = new ArrayList();
        public static void Part1()
        {
            ArrayList grid = new ArrayList();
            int rowLenght = 0;
        
            foreach (string line in System.IO.File.ReadLines(@"Days\inputs\input_8.txt"))
            {  
                string[] splittedLine = line.Split("");
                ArrayList l = new ArrayList(splittedLine);
                rowLenght = l.Count;
                grid.Add(l);
            }

            for(int i = 0; i<grid.Count; i++){
                for(int j = 0; j<rowLenght; j++){

                }
            }
           
        }
    }
}
