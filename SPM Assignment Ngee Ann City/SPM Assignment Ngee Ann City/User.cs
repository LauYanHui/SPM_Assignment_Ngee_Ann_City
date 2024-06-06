using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM_Assignment_Ngee_Ann_City
{
    class User
    {
        private String name;
        public String Name { get; set; }

        private String password;
        public String Password { get; set; }

        private String email;
        public String Email { get; set; }

        private bool isSaved;
        public bool IsSaved { get; set; }

        private int points;
        public int Points { get; set; }

        public User() { }

        public User(string n,string pa, bool IS, int p)
        {
            Name = n;
            Password = pa;
            IsSaved = IS;
            Points = p;
        }

        public override string ToString()
        {
            return "Name: " + Name + "\tEmail: " + Email + "\tPoints: " + Points;
        }

    }
}
