using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM_Assignment_Ngee_Ann_City
{
    abstract class Building
    {
        public char type { get; set; }
        public char row { get; set; }
        public int col { get; set; }
        protected Grid grid { get; set; }   
        public Building(char type,char row, int col, Grid grid)
        {
            this.type = type;
            this.row = row;
            this.col = col;
            this.grid = grid;
        }
        public Building() { }
        
        public abstract void calculatePoints(int buildings);
        public abstract void calculateCoins();
        public abstract void calculateCointsFP();
    }
    
}
