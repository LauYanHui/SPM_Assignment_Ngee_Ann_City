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
        public Residential(char row,int col) : base('R', row,col)
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
