using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM_Assignment_Ngee_Ann_City
{
    class Residential : Building
    {
        public Residential() { }
        public Residential(char row,int col, Grid grid) : base('R', row,col, grid)
        {
        }
        public override int calculateCoins()
        {
            return 0;
            /*
            int rowIndex = this.row - 'A';
            int colIndex = this.col;

            int coins = 0;

            // Define directions: up, down, left, right, up-left, up-right, down-left, down-right
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

                    if (adjacentCell == 'I')
                    {
                        coins += 1; // 1 coin for each adjacent industry
                    }
                    else if (adjacentCell == 'R' || adjacentCell == 'C')
                    {
                        coins += 1; // 1 coin for each adjacent residential or commercial
                    }
                    else if (adjacentCell == 'O')
                    {
                        coins += 2; // 2 coins for each adjacent park
                    }
                }
            }
            coins += generateCoins();


            Console.WriteLine($"Residential building at {this.row}{this.col+1} generates {coins} coins based on adjacent buildings.");
            */
        }
        public override int calculatePoints(int buildings)
        {
            // Convert row letter to index
            int rowIndex = this.row - 'A';
            int colIndex = this.col;

            int points = 0;
            bool isNextToIndustry = false;

            // Define the relative positions for all adjacent cells, including diagonals
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

            // Check each adjacent cell
            foreach (var dir in directions)
            {
                int newRow = rowIndex + dir[0];
                int newCol = colIndex + dir[1];

                // Ensure the new position is within grid bounds
                if (newRow >= 0 && newRow < grid.Number && newCol >= 0 && newCol < grid.Number)
                {
                    char adjacentCell = grid.GetCell(newRow, newCol);

                    if (adjacentCell == 'I')
                    {
                        isNextToIndustry = true;
                        break;
                    }
                }
            }

            if (isNextToIndustry)
            {
                points = 1;
            }
            else
            {
                foreach (var dir in directions)
                {
                    int newRow = rowIndex + dir[0];
                    int newCol = colIndex + dir[1];

                    // Ensure the new position is within grid bounds
                    if (newRow >= 0 && newRow < grid.Number && newCol >= 0 && newCol < grid.Number)
                    {
                        char adjacentCell = grid.GetCell(newRow, newCol);

                        if (adjacentCell == 'R' || adjacentCell == 'C')
                        {
                            points += 1;
                        }
                        else if (adjacentCell == 'O')
                        {
                            points += 2;
                        }
                    }
                }
            }
            return points;
            //Console.WriteLine($"Residential building at {this.row}{this.col+1} has {points} points based on adjacent buildings.");
        }
        public override void calculateCointsFP()
        {
            throw new NotImplementedException();
        }


    }
}
