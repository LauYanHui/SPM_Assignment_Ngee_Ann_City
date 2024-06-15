using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM_Assignment_Ngee_Ann_City
{
    class Industry : Building
    {
        public Industry() { }
        public Industry(char row, int col, Grid grid) : base('I', row, col, grid)
        {

        }
        public override void calculateCoins()
        {
            int rowIndex = this.row - 'A';
            int colIndex = this.col;

            int coins = 0;

            int[][] directions = new int[][]
            {
                new int[] {-1, 0},  // up
                new int[] {1, 0},   // down
                new int[] {0, -1},  // left
                new int[] {0, 1},   // right
                new int[] {-1, -1}, // up-left
                new int[] {-1, 1},  // up-right
                new int[] {1, -1},  // down-left
                new int[] {1, 1}    // down-right
            };

            foreach (var dir in directions)
            {
                int newRow = rowIndex + dir[0];
                int newCol = colIndex + dir[1];

                if (newRow >= 0 && newRow < grid.Number && newCol >= 0 && newCol < grid.Number)
                {
                    char adjacentCell = grid.GetCell(newRow, newCol);

                    if (adjacentCell == 'R')
                    {
                        coins += 1;
                    }
                }
            }

            Console.WriteLine($"Industry building at {this.row}{this.col+1} generates {coins} coins based on adjacent residential buildings.");
        }
        public override void calculatePoints(int totalIndustries)
        {
            int points = totalIndustries;
            Console.WriteLine($"Industry building at {this.row}{this.col+1} has {points} points based on total industry buildings.");
        }
        public override void calculateCointsFP()
        {
            throw new NotImplementedException();
        }
    }
}
