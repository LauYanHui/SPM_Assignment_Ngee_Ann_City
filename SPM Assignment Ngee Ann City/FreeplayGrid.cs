using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM_Assignment_Ngee_Ann_City
{
    class FreeplayGrid : Grid
    {
        private int FPnumber;
        private int w = 0;
        private int a = 0;
        private int s = 0;
        private int d = 0;
        private List<int> X_range;
        private List<int> Y_range;
        public FreeplayGrid(int number) : base(number)
        {
            FPnumber = number;
            X_range = new List<int>();
            Y_range = new List<int>();
        }

        private void PrintGridMoreThan26()
        {
            char[,] grid = base.getGrid();
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            double MinCountLetters = Math.Ceiling(Convert.ToDouble(FPnumber) / letters.Length);
            int counter0 = 0;
            Console.Write("   ");
            for (int i = 0; i < MinCountLetters; i++)
            {
                for (int j0 = 0; j0 < letters.Length; j0++)
                {
                    Console.Write("  " + letters[i] + " ");
                    counter0++;
                    if (counter0 == FPnumber)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine();
            Console.Write("   ");
            int count = 0;
            int counter = 0;
            while (true)
            {
                for (int j1 = 0; j1 < letters.Length; j1++)
                {
                    Console.Write("  " + letters[j1] + " ");
                    counter++;
                    if (counter == FPnumber)
                    {
                        break;
                    }
                }
                count++;
                if (count >= MinCountLetters)
                {
                    break;
                }
            }
            //Console.WriteLine();
            //Console.Write(" ");
            //Console.WriteLine("  +" + new string('-', 4 * FPnumber) + "+");

            //for (int i = 0; i < FPnumber; i++)
            //{
            //    Console.Write($"{i + 1,2} |"); // Print the row number and vertical bar
            //    for (int j = 0; j < FPnumber; j++)
            //    {
            //        Console.Write($" {grid[i, j]} |"); // Print the content of each cell
            //    }
            //    Console.WriteLine();
            //    Console.Write(" ");
            //    Console.WriteLine("  +" + new string('-', 4 * FPnumber) + "+");
            //}
        }

        public void PrintGridFP()
        {
            char[,] grid = base.getGrid();
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            int defaultViewNum = 25;
            double MinCountLetters = Math.Ceiling(Convert.ToDouble(FPnumber) / letters.Length);
            int y_top = 1;
            int y_bottom = 25;
            int x_left = 1;
            int x_right = 25;
            if (Y_range.Count !=0)
            {
                y_top = Y_range[0];
                y_bottom = Y_range[1];
            }
            if(X_range.Count !=0)
            {
                x_left = X_range[0];
                x_right = X_range[1];
            }


            Console.WriteLine("Grid size : " + FPnumber);
            Console.WriteLine(X_range.Count);
            //For moving X value


            int counter0 = 0;
            int counter = 0;
            int breakpoint = 0;
            int firstRowFirstLetterIndex = Convert.ToInt32(Math.Floor(Convert.ToDecimal((x_left) / letters.Length)));
            int firstRowLastLetterIndex = Convert.ToInt32(Math.Floor(Convert.ToDecimal((x_right) / letters.Length)));
            Console.Write("     ");
            for (int i = 0; i < defaultViewNum; i++)
            {
                char FirstRowFirstLetter = letters[firstRowFirstLetterIndex];
                char FirstRowLastLetter = letters[firstRowLastLetterIndex];
                char LetterToBePrinted = FirstRowFirstLetter;
                if (FirstRowFirstLetter != FirstRowLastLetter) //There is a change of letters
                {
                    int tempCounter = 0;
                    while (true)
                    {
                        if ((x_left + tempCounter) % letters.Length == 0)
                        {
                            breakpoint = x_left + tempCounter;
                            break;
                        }
                        tempCounter++;
                    }
                }
                if (x_left + counter0 > breakpoint)
                {
                    LetterToBePrinted = FirstRowLastLetter;
                }
                Console.Write(LetterToBePrinted + "   ");
                counter++;
                counter0++;
            }

            Console.WriteLine();
            Console.Write("     ");
            int counter1 = 0;
            
            x_left = x_left - 1;
            while (x_left > 26)
            {
                x_left -= 26;
            }
            for (int i = 0; i < defaultViewNum; i++)
            {
                if (x_left + i >= 26)
                {
                    x_left = 0;
                    counter1 = 0;
                }


                Console.Write(letters[x_left + counter1] + "   ");
                counter1++;
            }
            Console.WriteLine();

            Console.WriteLine("   +" + new string('-', 4 * defaultViewNum) + "+");
            for (int i = y_top - 1; i < y_bottom; i++)
            {
                Console.Write($"{i + 1,2} |"); // Print the row number and vertical bar
                for (int j = 0; j < defaultViewNum; j++)
                {
                    Console.Write($" {grid[i, j]} |"); // Print the content of each cell
                }
                Console.WriteLine();
                Console.Write(" ");
                Console.WriteLine("  +" + new string('-', 4 * defaultViewNum) + "+");
            }





            Console.WriteLine();

            

        }
        //since terminal support size grid without expanding or zooming out is ard 25~30, we make it move out at 25 so...
        //grid increases from 5x5 to 15x15 to 25x25 : pattern => increasing by 10
        //
        public void MoveGridView(String movement)
        {
            //Default view port 25x25
            int new_top;
            int new_bottom;
            int new_left;
            int new_right;
            
            
            if ((movement.ToLower()).Equals("w")) //UP
            {
                
                if(Y_range.Count != 0)
                {
                    if (Y_range[0] == 1) //At the top
                    {
                        Console.WriteLine("Already at the top");
                        return;
                    }
                    Y_range.Clear();
                }
                else //For the first input
                {
                    Y_range.Add(1);
                    Y_range.Add(25);
                    Console.WriteLine("Already at the top");
                    return;
                }
                //Moving up by 10 grid 
                w--;
                int Y_Coordinate = w * 10;
                int original_top = 1;
                int original_bottom = 25;
                new_top = original_top + Y_Coordinate;
                new_bottom = original_bottom + Y_Coordinate;
                Y_range.Add(new_top);
                Y_range.Add(new_bottom);
                //Array = original +10 x original
                //Let original = 35 last row
                //After w, should be 1-25 instead of 11-35
                //Moving up = Y coordinate minus


                //displaying coordinates from 11-35 instead of 1-25


            }
            else if ((movement.ToLower()).Equals("a")) //LEFT
            {
                if (X_range.Count != 0)
                {

                    if (X_range[0] == 1)
                    {
                        Console.WriteLine("Already at the edge");
                        return;
                    }
                    X_range.Clear();
                }
                else
                {
                    X_range.Add(1);
                    X_range.Add(25);
                    Console.WriteLine("Already at the edge");
                    return;
                }
                d--;
                int X_Coorindata = d * 10;
                int original_left = 1;
                int original_right = 25;
                new_left = original_left + X_Coorindata;
                new_right = original_right + X_Coorindata;
                X_range.Add(new_left);
                X_range.Add(new_right);
            }
            else if ((movement.ToLower()).Equals("s")) //DOWN
            {
                
                if (Y_range.Count != 0)
                {
                    if (Y_range[1] == FPnumber) //At the top
                    {
                        Console.WriteLine("Already at the bottom");
                        return;
                    }
                    Y_range.Clear();
                }
                //else
                //{
                //    Y_range.Add(1);
                //    Y_range.Add(25);
                //    PrintGridFP();
                //    return;
                //}
                w++;
                int Y_Coordinate = w * -10;
                int original_top = 1;
                int original_bottom = 25;
                new_top = original_top - Y_Coordinate;
                new_bottom = original_bottom - Y_Coordinate;
                Y_range.Add(new_top);
                Y_range.Add(new_bottom);
            }
            else if((movement.ToLower()).Equals("d"))// Movement = D RIGHT
            {
                
                if (X_range.Count != 0)
                {
                    if (X_range[1] == FPnumber)
                    {
                        Console.WriteLine("Already at the edge");
                        return;
                    }
                    X_range.Clear();
                }
                //else
                //{
                //    X_range.Add(1);
                //    X_range.Add(25);
                //    PrintGridFP();
                //    return;
                //}
                d++;
                int X_Coorindata = d * 10;
                int original_left = 1;
                int original_right = 25;
                new_left = original_left + X_Coorindata;
                new_right = original_right + X_Coorindata;
                X_range.Add(new_left);
                X_range.Add(new_right);

            }
            //Console.WriteLine(Y_Range[0] + "\t" + Y_Range[1]);
            PrintGridFP();
        }
        public void ExportGameDetails()
        {
            char[,] grid = base.getGrid();
            Console.WriteLine("test");
            /*for (int i = 0; i < Number; i++)
            {
                //Console.Write((i + 1) + ",");
                for (int j = 0; j < Number; j++)
                {
                    Console.Write(grid[i, j] + (j < Number - 1 ? "," : ""));
                }
                Console.WriteLine();
            }*/
        }

    }
}
