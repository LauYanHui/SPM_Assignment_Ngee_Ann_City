using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SPM_Assignment_Ngee_Ann_City
{
    class Grid
    {
        public int coins { get; set; }
        public int Number { get; set; }


        private char[,] grid;
        public List<Building> Buildings;



        public Grid(int number)
        {
            coins = 16;
            Number = number;
            grid = new char[number, number]; // Initialize the grid
            Buildings = new List<Building>();
            InitializeGrid(); // Initialize grid with empty spaces
        }

        public virtual void PrintGrid()
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

        public virtual char GetCell(int col, int row)
        {
            return grid[row, col];
        }
        public virtual bool IsConnectedToExistingBuilding(int row, int col, bool import)
        {
            if (Buildings.Count == 0 || import)
            {
                return true; // First building can be placed anywhere
            }
            // Define all eight directions
            int[][] directions = new int[][]
            {
                new int[] {-1, 0},  // up
                new int[] {1, 0},   // down
                new int[] {0, -1},  // left
                new int[] {0, 1},   // right
                new int[] {-1, -1}, // top left
                new int[] {-1, 1},  // top right
                new int[] {1, -1},  // bottom left
                new int[] {1, 1}    // bottom right
            };

            foreach (var dir in directions)
            {
                int newRow = row + dir[0];
                int newCol = col + dir[1];

                if (newRow >= 0 && newRow < Number && newCol >= 0 && newCol < Number && grid[newCol, newRow] != ' ')
                {
                    return true; // Found adjacent existing building
                }

            }

            return false; // No adjacent existing building
        }

        public bool AddBuilding(char buildingType, char rowLetter, int col, bool import)
        {
            int row = rowLetter - 'A';

            if (grid[col, row] != ' ' && import == false)
            {
                Console.WriteLine("Error: Building already exists at this location.");
                return false;
            }


            if (!IsConnectedToExistingBuilding(row, col, import))
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
                    newBuilding = new Residential(rowLetter, col, this);
                    break;
                case 'I':
                    newBuilding = new Industry(rowLetter, col, this);
                    break;
                case 'C':
                    newBuilding = new Commercial(rowLetter, col, this);
                    break;
                case 'O':
                    newBuilding = new Park(rowLetter, col, this);
                    break;
                case '*':
                    newBuilding = new Road(rowLetter, col, this);
                    break;
            }

            if (newBuilding != null)
            {
                Buildings.Add(newBuilding);
                coins--; // Deduct one coin for placing a building
                coins = coins += newBuilding.calculateCoins();
                return true; // Building added successfully
            }
            else
            {
                return false; // Error in building type
            }

        }

        public void RemoveBuilding(char rowLetter, int col)
        {
            int row = rowLetter - 'A';

            // Check if there is a building at the specified location
            if (grid[col, row] == ' ')
            {
                Console.WriteLine("There is no building at this location.");
                return;
            }

            grid[col, row] = ' ';
            Buildings.RemoveAll(r => r.row == rowLetter && r.col == col);
            coins--;
            Console.WriteLine("Building removed successfully.");
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
        public virtual void ExportGridToCSV(ref string filename )
        {
            Console.WriteLine();
            while (File.Exists(filename))
            {
                Console.WriteLine("A file with this name already exists. Please enter a different filename:");
                filename = Console.ReadLine();
            }
            if (!filename.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            {
                filename += ".csv";
            }

            // Check for spaces in the filename
            while (filename.Contains(" ") || File.Exists(filename))
            {
                Console.WriteLine("Invalid filename. Please enter a different filename (no spaces):");
                filename = Console.ReadLine();

                // Ensure it still ends with .csv
                if (!filename.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                {
                    filename += ".csv";
                }
            }
            using (StreamWriter sw = new StreamWriter(filename, false))
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
        public int calculateAllPoints()
        {
            //Console.WriteLine("test");
            int industryCount = 0;
            int test = 0;
            int points = 0;
            foreach (Building building in Buildings)
            {

                if (building is Industry)
                {
                    industryCount++;
                }
            }
            points += industryCount;
            foreach (var building in Buildings)
            {
                if (building is Residential residential)
                {
                    points += residential.calculatePoints(test);
                }
                else if (building is Commercial commercial)
                {
                    points += commercial.calculatePoints(test);
                }
                else if (building is Road road)
                {
                    points += road.calculatePoints(test);
                }
                else if (building is Park park)
                {
                    points += park.calculatePoints(test);
                }
            }
            return points;
        }
        public void Deductcoins(int amount)
        {
            if (amount <= coins)
            {
                coins -= amount;
            }
            else
            {
                Console.WriteLine("Not enough coins.");
            }
        }
        public int GetCoins()
        {
            return coins;
        }
        public void GenerateCoins()
        {
            //Console.WriteLine("test1");
            foreach (Building building in Buildings)
            {
                coins += building.calculateCoins();
            }
        }
        public  Grid ImportSavedGameArcade(Grid grid, string filename)
        {
            char[] letters = "ABCDEFGHIJKLMNOPQRST".ToCharArray();
            List<string> game_temp = new List<string>();
            List<List<String>> game_dataFinal = new List<List<String>>();
            using (StreamReader sr = new StreamReader(filename))
            {
                string? s = sr.ReadLine();
                if (s != null)
                {
                    //Console.WriteLine(s);
                    game_temp.Add(s);
                }
                while ((s = sr.ReadLine()) != null)
                {
                    //Console.WriteLine(s);
                    game_temp.Add(s);
                }
            }

            foreach (string s in game_temp)
            {
                List<string> game_data = new List<string>();
                string[] temp = new string[] { };
                temp = s.Split(",");
                int count = 0;
                foreach (string s1 in temp)
                {
                    game_data.Add(s1);
                    //Console.WriteLine(s1);
                }
                game_dataFinal.Add(game_data);
            }
            //Console.WriteLine(game_dataFinal[19].Count);

            for (int i = 0; i < game_dataFinal.Count; i++)
            {
                for (int j = 0; j < game_dataFinal[i].Count; j++)
                {
                    string data = game_dataFinal[i][j];
                    //Console.WriteLine(game_dataFinal[i][j]);
                    if (data != " ")
                    {
                        char[] dataChar = data.ToCharArray();
                        grid.AddBuilding(dataChar[0], letters[j], i, true);
                        //Console.WriteLine(String.Format("{0}    {1}    {2}", data, i.ToString(), j.ToString()));
                    }
                }
            }
            return grid;
        }
        public int ConvertToNumber(string input)
        {
            int result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                result *= 26;
                result += (input[i] - 'A');
            }
            return result;
        }

        public List<Building> getlist()
        {
            return Buildings;
        }

        public char[,] getGrid()
        {
            return grid;
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

            if (!IsConnectedToExistingBuilding(row, col, import))
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
                //coins--; // Deduct one coin for placing a building
                //coins += newBuilding.calculateCoins();
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
        public void calculateCoinsFP()
        {
            Console.WriteLine("test");
            foreach (Building B in Buildings)
            {
                coins += B.Income();
                Console.WriteLine("Coins is " + coins);
                coins -= B.Upkeep();
                Console.WriteLine("Coins is " + coins);
            }
        }
    }
}