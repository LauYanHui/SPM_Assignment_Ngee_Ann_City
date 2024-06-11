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

        public Grid(int number)
        {
            Number = number;
            grid = new char[number, number]; // Initialize the grid
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

        public void AddBuilding(char buildingType, char rowLetter, int col)
        {
            int row = rowLetter - 'A'; // Convert letter to corresponding numeric row index
            grid[col, row] = buildingType; // Place the building type at the specified coordinates
        }

        public void RemoveBuilding( char rowLetter, int col)
        {
            int row = rowLetter - 'A';
            grid[col, row] = ' ';
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
    }
}
