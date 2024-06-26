﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM_Assignment_Ngee_Ann_City
{
    class User : IComparable<User>
    {
        private String name;
        public String Name { get; set; }

//        private String password;
//        public String Password { get; set; }

//        private String email;
//        public String Email { get; set; }

//        private bool isSaved;
//        public bool IsSaved { get; set; }

        private int points;
        public int Points { get; set; }

        public User() { }

        public User(string n, int p)
        {
            Name = n;
            Points = p;
        }

        public override string ToString()
        {
            return "Name: " + Name + "\tPoints: " + Points;
        }
        

        interface IComparable<User>
        {
            int CompareTo(User obj);
        }
        public int CompareTo(User u)
        {
            //Sorted descending
            return u.Points.CompareTo(Points);
        }

    }
}
