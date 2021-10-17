using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Class that holds the high scores.
        /// </summary>
        Scores Scores;

        /// <summary>
        /// Class that holds the user data.
        /// </summary>
        UserData UserData;

        /// <summary>
        /// Class where the game is played.
        /// </summary>
        Game Game;

        public MainWindow()
        {
            InitializeComponent();

            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

            Scores = new Scores();
            UserData = new UserData();
            Game = new Game();

            //Pass the high scores form to the game form.  This way the high scores form may be displayed via the game form.
            Game.CopyHighScores = Scores;
        }

        private void play_game_Click(object sender, RoutedEventArgs e)
        {
            //Hide the menu
            this.Hide();
            //Show the game form
            Game.ShowDialog();
            //Show the main form
            this.Show();
        }

        private void high_scores_Click(object sender, RoutedEventArgs e)
        {
            //Hide the menu
            this.Hide();
            //Show the high scores screen
            Scores.ShowDialog();
            //Show the main form
            this.Show();
        }

        private void user_data_Click(object sender, RoutedEventArgs e)
        {
            //Hide the menu
            this.Hide();
            //Show the user data form
            UserData.ShowDialog();
            //Show the main form
            this.Show();
        }
    }
}
