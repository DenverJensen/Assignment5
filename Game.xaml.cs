using System;
using System.Timers;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;



namespace Assignment5
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Game : Window
    {

        private Scores Scores;
        public MathGame session;

        private static System.Timers.Timer aTimer;
        private static int times = 0;


        public Game()
        {
            InitializeComponent();
            times = 0;
            session = new MathGame();
        }

        public Scores CopyHighScores
        {
            get { return Scores; }
            set { Scores = value; }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void end_game_Click(object sender, RoutedEventArgs e)
        {
            ResetForm();
            times = 0;
            this.Hide();
        }

        private void high_scores_Click(object sender, RoutedEventArgs e)
        {
            //Hide the game form
            this.Hide();
            //Show the high scores
            Scores.ShowDialog();
        }

        public void LoadUserInfo(string name, int age, MathGame.Operation op)
        {
            string userinfo = String.Concat(name, "  (", age.ToString(), ")");
            txt_user_info.Content = userinfo;
            session.eOperation = op;
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            
            stk_questions.Visibility = Visibility.Visible;
            lbl_timer.Visibility = Visibility.Visible;
            stk_game_info.Visibility = Visibility.Visible;
            lbl_correct.Content = "Correct Answers: 0";
            lbl_question_num.Content = "Question #1";
            lbl_incorrect.Content = "Incorrect Answers: 0";
            session.correct = 0;
            session.wrong = 0;
            session.question_num = 1;
            SetTimer();
            lbl_question.Content = session.GenerateQuestion();
            txt_answer.Focus();
        }
        public void SetTimer()
        {
            if (times > 0)
            {
                times = 0;
            }
            else
            {
                btn_start.Visibility = Visibility.Hidden;
                // Create a timer with a two second interval.
                aTimer = new System.Timers.Timer(1000);
                // Hook up the Elapsed event for the timer. 
                aTimer.Start();
                aTimer.Elapsed += OnTimedEvent;

                aTimer.AutoReset = true;
                aTimer.Enabled = true;
            }
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Dispatcher.Invoke((ThreadStart)delegate
            {
                lbl_timer.Content = (++times).ToString();
            }, null);
        }

        private void lbl_submit_Click(object sender, RoutedEventArgs e)
        {
            int input; //The current number in the guess
            if (!Int32.TryParse(txt_answer.Text, out input))
            {
            }
            else
            {
                session.SubmitAnswer(input);
                UpdateResults();
                txt_answer.Text = null;
                txt_answer.Focus();
            }
            if (session.isOver)
            {
                ResetForm();
                
                times = 0;
                session.isOver = false;
                this.Hide();
                //Show the high scores
                Scores.ShowDialog();
            }
            else
            {
                lbl_question.Content = session.GenerateQuestion();
            }
        }

        private void ResetForm()
        {
            stk_questions.Visibility = Visibility.Hidden;
            lbl_timer.Visibility = Visibility.Hidden;
            btn_start.Visibility = Visibility.Visible;
            lbl_result.Visibility = Visibility.Hidden;
            stk_game_info.Visibility = Visibility.Hidden;
        }

        private void UpdateResults()
        {
            if (session.isCorrect)
            {
                lbl_result.Content = "Correct!!!";
            }
            else
            {
                lbl_result.Content = "Wrong!  " + "(" + session.answer.ToString() + ")";
            }
            stk_game_info.Visibility = Visibility.Visible;
            lbl_correct.Content = "Correct Answers: " + session.correct.ToString();
            lbl_question_num.Content = "Question #" + session.question_num.ToString();
            lbl_incorrect.Content = "Incorrect Answers: " + session.wrong.ToString();
            lbl_result.Visibility = Visibility.Visible;
        }
    }
}
