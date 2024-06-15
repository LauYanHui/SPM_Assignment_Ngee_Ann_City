using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM_Assignment_Ngee_Ann_City
{
    class Road : Building
    {
        public Road() { }
        public Road(char row, int col, Grid grid) : base('*', row, col, grid)
        {

        }
        public override void calculateCoins()
        {
            throw new NotImplementedException();
        }
        public override void calculatePoints(int buildings)
        {
            int rowIndex = this.row - 'A';
            int colIndex = this.col;

            int points = 0;

            // Check left from the current position
            int leftCol = colIndex - 1;
            while (leftCol >= 0 && grid.GetCell(rowIndex, leftCol) == '*')
            {
                points++;
                leftCol--;
            }

            // Check right from the current position
            int rightCol = colIndex + 1;
            while (rightCol < grid.Number && grid.GetCell(rowIndex, rightCol) == '*')
            {
                points++;
                rightCol++;
            }

            Console.WriteLine($"Road at {this.row}{this.col+1} has {points} points based on connected roads in the same row.");
        }
    }
}
