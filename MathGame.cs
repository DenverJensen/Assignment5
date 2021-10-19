using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    public class MathGame
    {


        public int correct = 0;

        public int wrong = 0;

        public int num1;

        public int num2;

        public int answer;

        public int guess;

        public int question_num = 1;

        public Random random;

        public bool isCorrect;

        public bool isOver = false;


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

        public string OperationString()
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

        public string GenerateQuestion()
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


        private string formatQuestion()
        {
            string question;
            question = num1.ToString() + " " + OperationString() + " " + num2.ToString() + " = ___";
            return question;
        }
        private void getAdd()
        {
            random = new Random();
            int x = random.Next(1, 11);
            int y = random.Next(1, 11);
            num1 = x;
            num2 = y;
            answer = x + y;
        }

        private void getSub()
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

        private void getDivide()
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

        private void getMultiply()
        {
            random = new Random();
            int x = random.Next(1, 11);
            int y = random.Next(1, 11);
            num1 = x;
            num2 = y;
            answer = x * y;
        }

        public void SubmitAnswer(int input_guess)
        {
            if(question_num == 10)
            {
                isOver = true;
            }
            guess = input_guess;
            grade();
        }

        public void grade()
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
    }
}
