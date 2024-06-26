﻿using System;
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
        private bool IsConnectedToExistingBuilding(int row, int col,bool import)
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


            if (!IsConnectedToExistingBuilding(row, col,import))
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
        public void ExportGridToCSV()
        {
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
        public int calculateAllPoints()
        {
            int industryCount = 0;
            int test = 0;
            int points = 0;
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
                    points += residential.calculatePoints(test);
                }
                else if (building is Industry industry)
                {
                    points += industry.calculatePoints(industryCount);
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
        public Grid ImportSavedGameArcade(Grid grid)
        {
            char[] letters = "ABCDEFGHIJKLMNOPQRST".ToCharArray();
            List<string> game_temp = new List<string>();
            List<List<String>> game_dataFinal = new List<List<String>>();
            using (StreamReader sr = new StreamReader("saved_game_data_arcade.csv"))
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
                        grid.AddBuilding(dataChar[0], letters[j], i,true);
                        //Console.WriteLine(String.Format("{0}    {1}    {2}", data, i.ToString(), j.ToString()));
                    }
                }
            }
            return grid;
        }
        public List<Building> getlist()
        {
            return Buildings;
        }
    }
}
