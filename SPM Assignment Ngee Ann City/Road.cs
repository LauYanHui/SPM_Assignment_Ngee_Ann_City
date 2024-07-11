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
        public Road(int row, int col, Grid grid) : base('*', row, col, grid)
        {

        }
        public override int calculateCoins()
        {
            return 0;
        }
        public override int calculatePoints(int buildings)
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
            return points;
            //Console.WriteLine($"Road at {this.row}{this.col+1} has {points} points based on connected roads in the same row.");
        }
        public override int Income()
        {
            return 0;
        }
        public override int Upkeep()
        {
            return CalculateUpkeepCost();
        }
        private int CalculateUpkeepCost()
        {
            // Upkeep cost for a road segment is 1 coin if it is not connected to any other road segments
            int rowIndex = this.row - 'A';
            int colIndex = this.col;

            bool connected = false;

            // Check left
            if (colIndex > 0 && grid.GetCell(rowIndex, colIndex - 1) == '*')
            {
                connected = true;
            }

            // Check right
            if (colIndex < grid.Number - 1 && grid.GetCell(rowIndex, colIndex + 1) == '*')
            {
                connected = true;
            }

            // If not connected to any road segment, upkeep cost is 1 coin
            return connected ? 0 : 1;
        }
    }
}