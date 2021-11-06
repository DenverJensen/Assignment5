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
using System.Media;
using System.Reflection;

namespace Assignment5
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Game : Window
    {
        /// <summary>
        /// class to hold score data for window
        /// </summary>
        private Scores Scores;

        /// <summary>
        /// class to hold game info for math game
        /// </summary>
        public MathGame session;

        /// <summary>
        /// timer for game form
        /// </summary>
        private static System.Timers.Timer aTimer;

        /// <summary>
        /// variable to hold current number of seconds elapsed since start
        /// </summary>
        private static int times = 0;

        /// <summary>
        /// main method. set time elapsed to 0 and generate new game session
        /// </summary>
        public Game()
        {
            try
            {
                InitializeComponent();
                times = 0;
                session = new MathGame();
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            };
        }

        /// <summary>
        /// class to hold score values for window
        /// </summary>
        public Scores CopyHighScores
        {
            get { return Scores; }
            set { Scores = value; }
        }

        /// <summary>
        /// method to cancel game and close window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                this.Hide();
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            };
        }

        /// <summary>
        /// method for end game button. method resets time elapsed to 0 and hides the game form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void end_game_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ResetForm();
                times = 0;
                this.Hide();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            };
        }

        /// <summary>
        /// method to start game. resets all scores to 0 and shows the game question and results panels
        /// first question is generated, sets focus to answer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            };
        }

        /// <summary>
        /// method to load user info to game panel from the main window
        /// sets user infor to name (age)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="op"></param>
        public void LoadUserInfo(string name, int age, MathGame.Operation op)
        {
            try
            {
                string userinfo = String.Concat(name, "  (", age.ToString(), ")");
                Scores.Player = String.Concat(name, "  (", age.ToString(), ")");
                txt_user_info.Content = userinfo;
                session.eOperation = op;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// initialize timer. if timer is not 0, set to 0 and hook up event handler
        /// </summary>
        public void SetTimer()
        {
            try
            {
                if (times > 0)
                {
                    times = 0;
                }
                else
                {
                    btn_start.Visibility = Visibility.Hidden;
                    aTimer = new System.Timers.Timer(1000);
                    // Hook up the Elapsed event for the timer. 
                    aTimer.Start();
                    aTimer.Elapsed += OnTimedEvent;

                    aTimer.AutoReset = true;
                    aTimer.Enabled = true;
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
        /// increment timer every second
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            try
            {
                Dispatcher.Invoke((ThreadStart)delegate
                {
                    lbl_timer.Content = (++times).ToString();
                }, null);
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// method to handle submittion of user input as answer
        /// method checks the answer and updates user scores
        /// if the game is not over, a new question is generated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_submit_Click(object sender, RoutedEventArgs e)
        {
            try
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
                    session.end_time = times;

                    times = 0;
                    session.isOver = false;
                    this.Hide();
                    Scores.Correct = session.correct;
                    Scores.Wrong = session.wrong;
                    Scores.End_time = session.end_time;
                    Scores.LoadResults();
                    //Show the high scores
                    Scores.ShowDialog();
                }
                else
                {
                    lbl_question.Content = session.GenerateQuestion();
                }

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            };
        }

        /// <summary>
        /// reset form and hide all game components until start game button us pressed.
        /// </summary>
        private void ResetForm()
        {
            try
            {
                stk_questions.Visibility = Visibility.Hidden;
                lbl_timer.Visibility = Visibility.Hidden;
                btn_start.Visibility = Visibility.Visible;
                lbl_result.Visibility = Visibility.Hidden;
                stk_game_info.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// method to update results after user input is submitted. 
        /// if correct hulk smash sound is played, a buzzer if incorrect
        /// </summary>
        private void UpdateResults()
        {
            try
            {
                if (session.isCorrect)
                {
                    lbl_result.Content = "Correct!!!";
                    SoundPlayer simpleSound = new SoundPlayer("sounds/smash_wav.wav");
                    simpleSound.Play();
                }
                else
                {
                    lbl_result.Content = "Wrong!  " + "(" + session.answer.ToString() + ")";
                    SoundPlayer simpleSound = new SoundPlayer("sounds/buz.wav");
                    simpleSound.Play();
                }
                stk_game_info.Visibility = Visibility.Visible;
                lbl_correct.Content = "Correct Answers: " + session.correct.ToString();
                lbl_question_num.Content = "Question #" + session.question_num.ToString();
                lbl_incorrect.Content = "Incorrect Answers: " + session.wrong.ToString();
                lbl_result.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// method to handle errors
        /// </summary>
        /// <param name="sClass">The class in which the error occurred in.</param>
        /// <param name="sMethod">The method in which the error occurred in.</param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                //Would write to a file or database here.
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }
    }
}
