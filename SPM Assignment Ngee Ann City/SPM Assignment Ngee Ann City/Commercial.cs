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
        public Commercial(char row, int col) : base('C', row, col)
        {

        }
        public override void calculateCoins()
        {
            throw new NotImplementedException();
        }
        public override void calculatePoint()
        {
            throw new NotImplementedException();
        }
    }
}
