using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM_Assignment_Ngee_Ann_City
{
    class Park : Building
    {
        public Park() { }
        public Park(char row, int col) : base('P', row, col)
        {

        }
        public override void calculatePoint()
        {
            throw new NotImplementedException();
        }
        public override void calculateCoins()
        {
            throw new NotImplementedException(); 
        }
    }
}
