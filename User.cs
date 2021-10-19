using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    public class User
    {
        private string name;

        private int age;

        private int[] scores;

        private int run_time;


        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public int[] Scores { get => scores; set => scores = value; }
        public int Run_time { get => run_time; set => run_time = value; }

        public bool IsNameValid(string name)
        {
            if (name == null || name == "")
            {
                return false;
            }
            foreach (char item in name)
            {
                if (!char.IsLetter(item))
                {
                    return false;
                }
            }

            return true;

        }

        public bool IsAgeValid(int age)
        {
                if (age > 2 && age < 11)
                {
                    return true;
                }
            
            return false;

        }
    }
}
