using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asztali_projekt_2026.Model
{
    internal class Class_Object
    {
        private int _id;
        private string _firstname;
        private string _lastname;
        private int _matches;
        private int _goals;
        private int _wins;
        private int _age;


        public Class_Object()
        {

        }

        public int Id { get => _id; set => _id = value; }
        public string Firstname { get => _firstname; set => _firstname = value; }
        public string Lastname { get => _lastname; set => _lastname = value; }
        public int Matches { get => _matches; set => _matches = value; }
        public int Goals { get => _goals; set => _goals = value; }
        public int Wins { get => _wins; set => _wins = value; }
        public int Age { get => _age; set => _age = value; }

        public Class_Object(int id, string firstname, string lastname, int matches, int goals, int wins, int age)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Matches = matches;
            Goals = goals;
            Wins = wins;
            Age = age;
        }

    }
}
