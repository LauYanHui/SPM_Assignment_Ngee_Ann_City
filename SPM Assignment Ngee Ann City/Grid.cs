using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM_Assignment_Ngee_Ann_City
{
    class Grid
    {
        public int Number { get; set; } // Change property name to PascalCase

        private char[,] grid; // Change to char[,] for simplicity
        private List<Building> Buildings;

        public Grid(int number)
        {
            Number = number;
            grid = new char[number, number]; // Initialize the grid
            Buildings = new List<Building>();
            InitializeGrid(); // Initialize grid with empty spaces
        }

        public void PrintGrid()
        {
            char[] letters = "ABCDEFGHIJKLMNOPQRST".ToCharArray();
            Console.Write(" ");
            Console.WriteLine("    " + string.Join("   ", letters)); // Print the letters with spaces and dashes
            Console.Write(" ");
            Console.WriteLine("  +" + new string('-', 4 * letters.Length - 1) + "+");

            for (int i = 0; i < Number; i++)
            {
                Console.Write($"{i + 1,2} |"); // Print the row number and vertical bar
                for (int j = 0; j < Number; j++)
                {
                    Console.Write($" {grid[i, j]} |"); // Print the content of each cell
                }
                Console.WriteLine();
                Console.Write(" ");
                Console.WriteLine("  +" + new string('-', 4 * letters.Length - 1) + "+");
            }
        }

        public char GetCell(int col, int row)
        {
            return grid[row, col];
        }

        public void AddBuilding(char buildingType, char rowLetter, int col)
        {
            int row = rowLetter - 'A'; // Convert letter to corresponding numeric row index
            grid[col, row] = buildingType; // Place the building type at the specified coordinates
            if (buildingType == 'R')
            {
                Buildings.Add(new Residential(rowLetter, col, this));
            }
            else if (buildingType == 'I')
            {
                Buildings.Add(new Industry(rowLetter, col, this));
            }
            else if (buildingType == 'C')
            {
                Buildings.Add(new Commercial(rowLetter, col, this));
            }
            else if (buildingType == 'O')
            {
                Buildings.Add(new Park(rowLetter, col, this));
            }
            else if (buildingType == '*')
            {
                Buildings.Add(new Road(rowLetter, col, this));
            }

        }

        public void RemoveBuilding( char rowLetter, int col)
        {
            int row = rowLetter - 'A';
            grid[col, row] = ' ';
            Buildings.RemoveAll(r => r.row == rowLetter && r.col == col);

        }

        private void InitializeGrid()
        {
            for (int i = 0; i < Number; i++)
            {
                for (int j = 0; j < Number; j++)
                {
                    grid[i, j] = ' '; // Initialize each cell with an empty space
                }
            }
        }
        public void ExportGridToCSV()
        {
            //char[] letters = "ABCDEFGHIJKLMNOPQRST".ToCharArray();
            //Console.Write(',');
            /*
            for(int i = 0;i<Number;i++)
            {
                Console.Write(letters[i] + (i < Number - 1 ? "," : ""));
            }
            */
            Console.WriteLine();
            using (StreamWriter sw = new StreamWriter("saved_game_data_arcade.csv", false))
            {
                for (int i = 0; i < Number; i++)
                {
                    //Console.Write((i + 1) + ",");
                    for (int j = 0; j < Number; j++)
                    {
                        Console.Write(grid[i, j] + (j < Number - 1 ? "," : ""));
                        sw.Write(grid[i, j] + (j < Number - 1 ? "," : ""));
                    }
                    Console.WriteLine();
                    sw.WriteLine();
                }

            }
                
        }
        public void calculateAllPoints()
        {
            int industryCount = 0;
            int test = 0;
            foreach (var building in Buildings)
            {
                
                if (building is Industry)
                {
                    industryCount++;
                }    
            }
            foreach(var building in Buildings)
            {
                if (building is Residential residential)
                {
                    residential.calculatePoints(test);
                }
                else if (building is Industry industry)
                {
                    industry.calculatePoints(industryCount);
                }
                else if (building is Commercial commercial)
                {
                    commercial.calculatePoints(test);
                }
                else if (building is Road road)
                {
                    road.calculatePoints(test);
                }
                else if (building is Park park)
                {
                    park.calculatePoints(test);
                }
            }
        }

    }
}
