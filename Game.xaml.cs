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
    public partial class Game : Window
    {

        private Scores Scores;
        public Game()
        {
            InitializeComponent();
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
            this.Hide();

        }

        private void high_scores_Click(object sender, RoutedEventArgs e)
        {
            //Hide the game form
            this.Hide();
            //Show the high scores
            Scores.ShowDialog();
        }
    }
}
