using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Assignment5
{
    public class MathGame
    {

        /// <summary>
        /// variable to hold current correct guesses
        /// </summary>
        public int correct { get; set; } = 0;

        /// <summary>
        /// variable to hold current wrong guesses
        /// </summary>
        public int wrong { get; set; } = 0;

        /// <summary>
        /// first number in generated math question
        /// </summary>
        public int num1 { get; set; }
        /// <summary>
        /// second number in generated math game
        /// </summary>
        public int num2 { get; set; }

        /// <summary>
        /// answer for generated question
        /// </summary>
        public int answer { get; set; }
        /// <summary>
        /// current user guess
        /// </summary>
        public int guess { get; set; }
        /// <summary>
        /// current question number (up to 10)
        /// </summary>
        public int question_num { get; set; } = 1;
        /// <summary>
        /// boolean if current guess == answer
        /// </summary>
        public bool isCorrect { get; set; }
        /// <summary>
        /// variable for end time of last question
        /// </summary>
        public int end_time { get; set; }
        /// <summary>
        /// variable to check if the game is over
        /// </summary>
        public bool isOver { get; set; } = false;
        /// <summary>
        /// class to generate random numbers
        /// </summary>
        public Random random;
        /// <summary>
        /// current math game operation
        /// </summary>
        public Operation eOperation { get; set; }
        /// <summary>
        /// enumerator for selecting operation
        /// </summary>
        public enum Operation
        {
            add,
            subtract,
            multiply,
            divide
        }
        /// <summary>
        /// method to return symbol for selected operation
        /// </summary>
        /// <returns>symbol for selected operation</returns>
        public string OperationString()
        {
            try
            {
                switch (eOperation)
                {
                    case Operation.add:
                        return "+";
                    case Operation.divide:
                        return "/";
                    case Operation.multiply:
                        return "*";
                    case Operation.subtract:
                        return "-";
                    default:
                        return null;
                }
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// method to generate new question based on selected operation
        /// </summary>
        /// <returns></returns>
        public string GenerateQuestion()
        {
            try
            {
                switch (eOperation)
                {
                    case MathGame.Operation.add:
                        getAdd();
                        break;
                    case MathGame.Operation.subtract:
                        getSub();
                        break;
                    case MathGame.Operation.multiply:
                        getMultiply();
                        break;
                    case MathGame.Operation.divide:
                        getDivide();
                        break;
                    default:
                        return eOperation.ToString();
                }
                return formatQuestion();
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// method to correctly format question
        /// </summary>
        /// <returns></returns>
        private string formatQuestion()
        {
            try
            {
                string question;
                question = num1.ToString() + " " + OperationString() + " " + num2.ToString() + " = ___";
                return question;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// method to get new addition question
        /// </summary>
        private void getAdd()
        {
            try
            {
                random = new Random();
                int x = random.Next(1, 11);
                int y = random.Next(1, 11);
                num1 = x;
                num2 = y;
                answer = x + y;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// method to generate new subtraction quesetion
        /// </summary>
        private void getSub()
        {
            try
            {
                random = new Random();
                int x = random.Next(1, 11);
                int y = random.Next(1, 11);
                if (x > y)
                {
                    num1 = x;
                    num2 = y;
                    answer = x - y;
                }
                else
                {
                    num1 = y;
                    num2 = x;
                    answer = y - x;
                }
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// method to generate new division question with whole int answer
        /// </summary>
        private void getDivide()
        {
            try
            {
                random = new Random();
                int x = random.Next(1, 6);

                int z;
                switch (x)
                {

                    case 5:
                        z = random.Next(1, 3);
                        answer = x;
                        num2 = z;
                        num1 = x * z;
                        break;
                    case 4:
                        z = random.Next(1, 3);
                        answer = x;
                        num2 = z;
                        num1 = x * z;
                        break;
                    case 3:
                        z = random.Next(1, 4);
                        answer = x;
                        num2 = z;
                        num1 = x * z;
                        break;
                    case 2:
                        z = random.Next(1, 6);
                        answer = x;
                        num2 = z;
                        num1 = x * z;
                        break;
                    case 1:
                        z = random.Next(1, 11);
                        answer = x;
                        num2 = z;
                        num1 = x * z;
                        break;
                }
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// method to generate new multiplication question
        /// </summary>
        private void getMultiply()
        {
            try
            {
                random = new Random();
                int x = random.Next(1, 11);
                int y = random.Next(1, 11);
                num1 = x;
                num2 = y;
                answer = x * y;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// method to submit guessed answer and invoke grade method
        /// if its the 10th question, the game is ended
        /// </summary>
        /// <param name="input_guess"></param>
        public void SubmitAnswer(int input_guess)
        {
            try
            {
                if (question_num == 10)
                {
                    isOver = true;
                }
                guess = input_guess;
                grade();
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// check if guess is correct and increment score variables
        /// </summary>
        private void grade()
        {
            try
            {
                if (guess == answer)
                {
                    correct++;
                    question_num++;
                    isCorrect = true;
                }
                else
                {
                    wrong++;
                    question_num++;
                    isCorrect = false;
                }
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
