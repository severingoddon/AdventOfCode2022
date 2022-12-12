using System;
using System.Collections.Generic;  

namespace Days
{
    class Day8Part1And2
    {
       private static List<List<char>> grid = new List<List<char>>();
       private static int count = 0;

       private static int currentTreeScore = 1;
       private static int highestTreeScore = 1;
        public static void Part1And2()
        {
        
            foreach (string line in System.IO.File.ReadLines("Days/inputs/input_8.txt"))
            {  
                char[] splittedLine = line.ToCharArray();
                grid.Add(new List<char>(splittedLine));
            }

            for(int i = 0; i<grid.Count; i++){
                for(int j = 0; j<grid[0].Count; j++){
                    if(i == 2 && j == 2){
                        int a = highestTreeScore;
                        Console.WriteLine("");
                    }

                    if(!(i==0 || i==grid.Count-1 || j== 0 || j==grid[0].Count-1)){
                        checkHighestTree(i,j,int.Parse((grid[i][j]).ToString()));
                    }
                       
                    if(currentTreeScore > highestTreeScore){
                        highestTreeScore = currentTreeScore;
                    }  
                    currentTreeScore = 1;
                }
            }
            Console.WriteLine(highestTreeScore);
           
        }

        private static bool checkHighestTree(int row, int col, int tree){
            checkTop(row,col,tree);
            checkBottom(row,col,tree);
            checkRight(row,col,tree);
            checkLeft(row,col,tree);
            return false;
        }

        private static bool checkTop(int row, int col, int tree){
            int distance = 0;
            for(int index = row-1; index >= 0; index--){
                if(int.Parse((grid[index][col]).ToString())>=tree){
                    distance++;
                    if(distance > 0) currentTreeScore*=distance;
                    return false;
                }
                distance++;
            }
            if(distance > 0) currentTreeScore*=distance;
            return true;

        
        }
        private static bool checkBottom(int row, int col, int tree){
            int distance = 0;
            for(int index = row+1; index < grid.Count; index++){
                if(int.Parse((grid[index][col]).ToString())>=tree){
                    distance++;
                    if(distance > 0) currentTreeScore*=distance;
                    return false;
                }
                distance++;
            }
            if(distance > 0) currentTreeScore*=distance;
            return true;

        }
        private static bool checkLeft(int row, int col, int tree){
            int distance = 0; 
            for(int index = col-1; index >= 0; index--){
                if(int.Parse((grid[row][index]).ToString())>=tree){
                    distance++;
                    if(distance > 0) currentTreeScore*=distance;
                    return false;
                }
                distance++;
            }
            if(distance > 0) currentTreeScore*=distance;
            return true;

        }
        private static bool checkRight(int row, int col, int tree){
            int distance = 0;
            for(int index = col+1; index < grid[0].Count; index++){
                if(int.Parse((grid[row][index]).ToString())>=tree){
                    distance++;
                    if(distance > 0) currentTreeScore*=distance;
                    return false;
                }
                distance++;
            }
            if(distance > 0) currentTreeScore*=distance;
            return true;

        }
    }
}
