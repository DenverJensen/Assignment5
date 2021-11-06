using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Assignment5
{
    public class User
    {
        /// <summary>
        /// variable to hold player name
        /// </summary>
        private string name;

        /// <summary>
        /// varaible to hold player age
        /// </summary>
        private int age;

        /// <summary>
        /// array to hold players scores
        /// </summary>
        private int[] scores;

        /// <summary>
        /// variable to hold the time for user
        /// </summary>
        private int run_time;

        /// <summary>
        /// public name variable for player name
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// public player age variable
        /// </summary>
        public int Age { get => age; set => age = value; }
        /// <summary>
        /// public score variable
        /// </summary>
        public int[] Scores { get => scores; set => scores = value; }
        /// <summary>
        /// public run time variable
        /// </summary>
        public int Run_time { get => run_time; set => run_time = value; }


        /// <summary>
        /// method to check if name is valid
        /// </summary>
        /// <param name="name"></param>
        /// <returns>true if name is valid</returns>
        public bool IsNameValid(string name)
        {
            try
            {
                if (name == null || name == "")
                {
                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// method to check if age is between 2 and 11
        /// </summary>
        /// <param name="age"></param>
        /// <returns>true if age between 2 and 11 </returns>
        public bool IsAgeValid(int age)
        {
            try
            {
                if (age > 2 && age < 11)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }
    }
}
