using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM_Assignment_Ngee_Ann_City
{
    class Commercial : Building
    {
        public Commercial() { }
        public Commercial(int row, int col, Grid grid) : base('C', row, col, grid)
        {

        }
        public override int calculateCoins()
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
                        //Console.WriteLine("test");
                        coins += 1;
                    }
                }
            }
            Console.WriteLine(coins);
            return coins += generateCoins();
        }
        public override int calculatePoints(int number)
        {
            int rowIndex;
            int colIndex;
            if (grid is FreeplayGrid)
            {
                rowIndex = this.col;
                colIndex = this.row;
            }
            else //Grid
            {
                rowIndex = this.row - 'A';
                colIndex = this.col;
            }

            int points = 0;

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

                    if (adjacentCell == 'C')
                    {
                        points += 1;
                    }
                }
            }
            return points;
            //Console.WriteLine($"Commercial building at {this.row}{this.col+1} has {points} points based on adjacent commercial buildings.");
        }
        public override int Income()
        {
            return 3;
        }
        public override int Upkeep()
        {
            return 2;
        }

    }
}
