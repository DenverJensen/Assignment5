using System;
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

namespace Assignment5
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Scores : Window
    {
        private string player;

        private int correct;

        private int wrong;

        private int end_time;

        public int Correct { get => correct; set => correct = value; }

        public int Wrong { get => wrong; set => wrong = value; }

        public int End_time { get => end_time; set => end_time = value; }

        public string Player { get => player; set => player = value; }



        public Scores()
        {
            InitializeComponent();

            LoadResults();
        }

        public void LoadResults()
        {
            string source;
            lbl_results.Content = Player + " \n";
            lbl_results.Content += "Correct: " + Correct + "\n";
            lbl_results.Content += "Wrong: " + Wrong ;
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

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void exit_scores_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
