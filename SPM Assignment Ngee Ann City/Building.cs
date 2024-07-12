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
        public int row { get; set; }
        public int col { get; set; }
        protected Grid grid { get; set; }   
        public Building(char type,int row, int col, Grid grid)
        {
            this.type = type;
            this.row = row;
            this.col = col;
            this.grid = grid;
        }
        public Building() { }
        
        public abstract int calculatePoints(int buildings);
        public abstract int calculateCoins();
        //public abstract int calculatePointsFP(int building);
        public abstract int Upkeep();
        public abstract int Income();
        
        public virtual int generateCoins()
        {
            return 0;
        }
    }
    
}
