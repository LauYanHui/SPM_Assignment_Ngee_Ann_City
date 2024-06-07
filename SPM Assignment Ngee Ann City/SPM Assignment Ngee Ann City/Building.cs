using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM_Assignment_Ngee_Ann_City
{
    class Building
    {
        private string type;
        private int points;
        private string position;

        public string Type { get; set; }
        public int Points { get; set; }
        public string Position { get; set; }
        public Building(string type, int points, string position)
        {
            Type = type;
            Points = points;
            Position = position;
        }
        public override string ToString()
        {
            return "Type: " + type + "\tPoints: " + points + "\tPosition" + position;
        }

    }
}
