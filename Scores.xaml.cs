using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assignment5
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Scores : Window
    {
        /// <summary>
        /// variable to hold player info
        /// </summary>
        private string player;

        /// <summary>
        /// variable for number of correct guesses
        /// </summary>
        private int correct;

        /// <summary>
        /// variable for number of incorrect guesses
        /// </summary>
        private int wrong;

        /// <summary>
        /// variable to hold final time
        /// </summary>
        private int end_time;

        /// <summary>
        /// public variable for number of correct guesses
        /// </summary>
        public int Correct { get => correct; set => correct = value; }

        /// <summary>
        /// public variable for number of wrong uesses
        /// </summary>
        public int Wrong { get => wrong; set => wrong = value; }
        /// <summary>
        /// public variable for final time
        /// </summary>
        public int End_time { get => end_time; set => end_time = value; }

        /// <summary>
        /// public variable for player info
        /// </summary>
        public string Player { get => player; set => player = value; }


        /// <summary>
        /// main method for scores window. initialize. 
        /// </summary>
        public Scores()
        {
            try
            {
                InitializeComponent();

                LoadResults();

            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            };
        }

        /// <summary>
        /// load the data into the results table from the variables in Scores class
        /// indicate if score is good, great or bad
        /// </summary>
        public void LoadResults()
        {
            try
            {
                string source;
                lbl_results.Content = Player + " \n";
                lbl_results.Content += "Correct: " + Correct + "\n";
                lbl_results.Content += "Wrong: " + Wrong;
                lbl_results.Content += "\nTime: " + End_time;

                if (correct > 7)
                {
                    source = "images/bruce_banner.jpg";
                    lbl_scores.Content = "Great Score!";
                }
                else if (correct > 4)
                {
                    source = "images/hulk_medium.jpg";
                    lbl_scores.Content = "Good Score!";
                }
                else
                {
                    source = "images/hulk_split.jpg";
                    lbl_scores.Content = "Keep Practicing";
                }
                ImageBrush myBrush = new ImageBrush(new BitmapImage(new Uri(@source, UriKind.Relative)));
                this.Background = myBrush;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            };
        }

        /// <summary>
        /// method to close window and cancel
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
        /// method to close scores window and restart game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exit_scores_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hide();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            };
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
