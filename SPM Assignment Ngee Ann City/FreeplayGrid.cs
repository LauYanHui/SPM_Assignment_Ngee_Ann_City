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
        private char[,] grid;
        public FreeplayGrid(int number) : base(number)
        {
            FPnumber = number;
            X_range = new List<int>();
            Y_range = new List<int>();
            grid = new char[FPnumber, FPnumber];
            InitializeGrid();
           
        }

        private void InitializeGrid()
        {
            
            for (int i = 0; i < FPnumber; i++)
            {
                for (int j = 0; j < FPnumber; j++)
                {
                    grid[i, j] = ' '; // Initialize each cell with an empty space
                }
            }
            if(Buildings.Count != 0)
            {
                foreach(Building build in Buildings)
                {
                    grid[build.col, build.row] = build.type;
                }
            }
        }
        //private void PrintGridMoreThan26()
        //{
        //    char[,] grid = base.getGrid();
        //    char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        //    double MinCountLetters = Math.Ceiling(Convert.ToDouble(FPnumber) / letters.Length);
        //    int counter0 = 0;
        //    Console.Write("   ");
        //    for (int i = 0; i < MinCountLetters; i++)
        //    {
        //        for (int j0 = 0; j0 < letters.Length; j0++)
        //        {
        //            Console.Write("  " + letters[i] + " ");
        //            counter0++;
        //            if (counter0 == FPnumber)
        //            {
        //                break;
        //            }
        //        }
        //    }

        //    Console.WriteLine();
        //    Console.Write("   ");
        //    int count = 0;
        //    int counter = 0;
        //    while (true)
        //    {
        //        for (int j1 = 0; j1 < letters.Length; j1++)
        //        {
        //            Console.Write("  " + letters[j1] + " ");
        //            counter++;
        //            if (counter == FPnumber)
        //            {
        //                break;
        //            }
        //        }
        //        count++;
        //        if (count >= MinCountLetters)
        //        {
        //            break;
        //        }
        //    }
        //    //Console.WriteLine();
        //    //Console.Write(" ");
        //    //Console.WriteLine("  +" + new string('-', 4 * FPnumber) + "+");

        //    //for (int i = 0; i < FPnumber; i++)
        //    //{
        //    //    Console.Write($"{i + 1,2} |"); // Print the row number and vertical bar
        //    //    for (int j = 0; j < FPnumber; j++)
        //    //    {
        //    //        Console.Write($" {grid[i, j]} |"); // Print the content of each cell
        //    //    }
        //    //    Console.WriteLine();
        //    //    Console.Write(" ");
        //    //    Console.WriteLine("  +" + new string('-', 4 * FPnumber) + "+");
        //    //}
        //}

        public override void PrintGrid()
        {
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            int defaultViewNum = 25;
            if ( FPnumber<15) //Starting grid at 5
            {
                defaultViewNum = 5;
            }
            else if(FPnumber == 15) //Grid size == 15
            {
                defaultViewNum = 15;
            }

            
            double MinCountLetters = Math.Ceiling(Convert.ToDouble(FPnumber) / letters.Length);
            int y_top = 1;
            int y_bottom = defaultViewNum;
            int x_left = 1;
            int x_right = defaultViewNum;
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
            Console.WriteLine("x_left: "+ x_left);
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
            
            int x_left_print = x_left - 1;
            while (x_left_print > 26)
            {
                x_left_print -= 26;
            }
            for (int i = 0; i < defaultViewNum; i++)
            {
                if (x_left_print + i >= 26)
                {
                    x_left_print = 0;
                    counter1 = 0;
                }


                Console.Write(letters[x_left_print + counter1] + "   ");
                counter1++;
            }
            Console.WriteLine();

            Console.WriteLine("   +" + new string('-', 4 * defaultViewNum) + "+");
            for (int i = y_top - 1; i < y_bottom; i++)
            {
                Console.Write($"{i + 1,2} |"); // Print the row number and vertical bar
                for (int j = 0; j < defaultViewNum; j++)
                {
                    Console.Write($" {grid[i, x_left-1 + j]} |"); // Print the content of each cell
                }
                Console.WriteLine();
                Console.Write(" ");
                Console.WriteLine("  +" + new string('-', 4 * defaultViewNum) + "+");
            }





            Console.WriteLine();

            

        }

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
            PrintGrid();
        }
        //public void ExportGameDetails()
        //{
        //    char[,] grid = base.getGrid();
        //    Console.WriteLine("test");
        //    /*for (int i = 0; i < Number; i++)
        //    {
        //        //Console.Write((i + 1) + ",");
        //        for (int j = 0; j < Number; j++)
        //        {
        //            Console.Write(grid[i, j] + (j < Number - 1 ? "," : ""));
        //        }
        //        Console.WriteLine();
        //    }*/
        //}
        public void ExpandGrid()
        {
            FPnumber += 10;
            char[,] tempgrid = new char[FPnumber, FPnumber];
            grid = tempgrid;
            //Console.WriteLine("buliding count b4: " + Buildings.Count);
            InitializeGrid();
            //Console.WriteLine("buliding count aft: " + Buildings.Count);

            PrintGrid();
        }



        public override bool IsConnectedToExistingBuilding(int col, int row, bool import) //Reversed col and row cuz it is wrong at first
        {
            return true;
            //if (Buildings.Count == 0 || import)
            //{
            //    return true; // First building can be placed anywhere
            //}
            //List<bool> adjacent_buildings = new List<bool>(); //If true, means got 1 direction have adjacent building

            //bool edge_left = false;
            //bool edge_right = false;
            //bool edge_top = false;
            //bool edge_bottom = false;
            

            //if(col-1 < 0) //Edge of the left map
            //{
            //    edge_left = true;
            //}
            //if(col + 1 >= FPnumber) //Edge of the right map
            //{
            //    edge_right = true;
            //}
            //if(row-1 < 0) //Edge of the top
            //{
            //    edge_top = true;
            //}
            //if(row + 1 >= FPnumber)//Edge of the bottom
            //{
            //    edge_bottom = true;
            //}
            ////Finding left of the new***** building
            ////left => row same, column -1 of the new,
            //bool left = false;
            //if(!edge_left)
            //{
            //    left = (grid[row, col - 1] != ' ');

            //}

            ////Find right of the new building
            ////right => row same, column + 1 of the new
            //bool right = false;
            //if(!edge_right)
            //{
            //    right = (grid[row, col + 1] != ' ');

            //}

            ////Find up of the new building
            ////up => col same, row + 1
            //bool up = false;
            //if (!edge_top)
            //{
                
            //    up = (grid[row - 1, col] != ' ');

            //}

            ////Finding down of the new building
            ////down => col same, row - 1
            //bool down = false;
            //if(!edge_bottom)
            //{
            //    down = (grid[row + 1, col] != ' ');
            //}

            ////Finding top-left of the new building
            ////top-left => row - 1 , col -1
            //bool top_left = false;
            //if( !edge_top && !edge_left)
            //{
            //    top_left = (grid[row - 1, col - 1] != ' ');

            //}

            ////Finding top-right of the new building
            ////top-right => row -1 ,col +1
            //bool top_right = false;
            //if( !edge_top && !edge_right )
            //{
            //    top_right = (grid[row - 1, col + 1] != ' ');

            //}

            ////Finding bottom_right of the new building
            ////bottom-right => row +1 , col +1
            //bool bottom_right = false;
            //if(!edge_bottom && !edge_right)
            //{
            //    bottom_right = (grid[row + 1, col + 1] != ' ');
            //}

            ////Finding bottom-left of the new building
            ////bottom-left => row + 1, col-1
            //bool bottom_left = false;
            //if (!edge_bottom && !edge_left)
            //{
            //    bottom_left = (grid[row + 1, col - 1] != ' ');
            //}

            
            //adjacent_buildings.Add(left);
            //adjacent_buildings.Add(right);
            //adjacent_buildings.Add(up);
            //adjacent_buildings.Add(down);
            //adjacent_buildings.Add(top_left);
            //adjacent_buildings.Add(top_right);
            //adjacent_buildings.Add(bottom_left);
            //adjacent_buildings.Add(bottom_right);

            //foreach(bool truth in adjacent_buildings)
            //{
            //    if (truth) //Adjacent building exists
            //    {
                    
            //        return true;
            //    }
            //}



            ////For debugging

            ////Console.WriteLine("Left: " + left);
            ////Console.WriteLine("Right: " + right);
            ////Console.WriteLine("Up: " +  up);
            ////Console.WriteLine("Down: " + down);
            ////Console.WriteLine("Top left: " + top_left);
            ////Console.WriteLine("Top right: " + top_right);
            ////Console.WriteLine("Bottom left: " + bottom_left);
            ////Console.WriteLine("Bottom right: " + bottom_right);
            ////Console.WriteLine("Row: " + row + " Col: " + col); 
            //return false;
        }




        public bool TestAddBuilding(char buildingType, int row, int col, bool import)
        {

            // Check if the coordinates are within the grid bounds (optional but recommended)
            if (row < 0 || row >= grid.GetLength(1) || col < 0 || col >= grid.GetLength(0))
            {
                Console.WriteLine("Error: Coordinates are out of bounds.");
                return false;
            }

            if (grid[col, row] != ' ' && !import)
            {
                Console.WriteLine("Error: Building already exists at this location.");
                return false;
            }

            if (!(IsConnectedToExistingBuilding(row, col, import)))
            {
                Console.WriteLine("Error: Building must be placed adjacent to an existing building.");
                return false;
            }

            // Place the building
            grid[col, row] = buildingType;

            // Create the building object and add to list
            Building newBuilding = null;
            switch (buildingType)
            {
                case 'R':
                    newBuilding = new Residential(row, col, this);
                    break;
                case 'I':
                    newBuilding = new Industry(row, col, this);
                    break;
                case 'C':
                    newBuilding = new Commercial(row, col, this);
                    break;
                case 'O':
                    newBuilding = new Park(row, col, this);
                    break;
                case '*':
                    newBuilding = new Road(row, col, this);
                    break;
            }

            if (newBuilding != null)
            {
                Buildings.Add(newBuilding);
                coins--; // Deduct one coin for placing a building
                coins += newBuilding.calculateCoins();


                Console.WriteLine("Col: " + col + " Row: " + row);
                if(row == 0)
                {
                    ExpandGrid();
                }
                else if(col == 0)
                {
                    ExpandGrid();
                }

                return true; // Building added successfully
            }
            else
            {
                return false; // Error in building type
            }
        }
        public void TestRemoveBuilding(int row, int col)
        {
            //int row = rowLetter - 'A';


            // Check if there is a building at the specified location
            if (grid[col, row] == ' ')
            {
                Console.WriteLine("There is no building at this location.");
                return;
            }

            grid[col, row] = ' ';
            Buildings.RemoveAll(r => r.row == row && r.col == col);
            coins--;
            Console.WriteLine("Building removed successfully.");
        }
    }
}
