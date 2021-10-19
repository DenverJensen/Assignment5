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

        User Player;

        /// <summary>
        /// Class that holds the user data.
        /// </summary>
       // UserData UserData;

        /// <summary>
        /// Class where the game is played.
        /// </summary>
        Game Game;

        public MainWindow()
        {
            InitializeComponent();

            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

            Scores = new Scores();
           // UserData = new UserData();
            Game = new Game();
            Player = new User();

            //Pass the high scores form to the game form.  This way the high scores form may be displayed via the game form.
            Game.CopyHighScores = Scores;
        }

        private void play_game_Click(object sender, RoutedEventArgs e)
        {
            // set player name and age from input
            bool allValid = true;
            int intAge;
            if (!Int32.TryParse(this.txt_age.Text, out intAge))
            {
           //     Player.Age = intAge;
            }
           // Player.name = txt_name.Text.ToString();

            //check for validation
            if (!Player.IsNameValid(txt_name.Text.ToString()))
            {
                lbl_name_error.Visibility = Visibility.Visible;
                allValid = false;
            }
            else
            {
                lbl_name_error.Visibility = Visibility.Hidden;
                Player.Name = txt_name.Text.ToString();
            }

            if (!Player.IsAgeValid(intAge))
            {
                lbl_age_error.Visibility = Visibility.Visible;
                allValid = false;
            }
            else
            {
                Player.Age = Int32.Parse(txt_age.Text.ToString());
                lbl_age_error.Visibility = Visibility.Hidden;
            }

            if (radio_division.IsChecked == false && radio_multiplication.IsChecked == false && radio_subtraction.IsChecked == false && radio_add.IsChecked == false)
            {
                lbl_select_error.Visibility = Visibility.Visible;
                allValid = false;
            }
            else
            {
                lbl_select_error.Visibility = Visibility.Hidden;
            }
            if(allValid)
            {

                //set math game operator based on selection
                MathGame.Operation op = new MathGame.Operation();
                if(radio_division.IsChecked == true)
                {
                    op = MathGame.Operation.divide;
                }

                if (radio_add.IsChecked == true)
                {
                    op = MathGame.Operation.add;
                }

                if (radio_multiplication.IsChecked == true)
                {
                    op = MathGame.Operation.multiply;
                }

                if (radio_subtraction.IsChecked == true)
                {
                    op = MathGame.Operation.subtract;
                }
                //valid input. set values to player object

                //Hide the menu
                this.Hide();
                //Show the game form
                Game.LoadUserInfo(Player.Name, Player.Age, op);
                Game.ShowDialog();
                //Show the main form
                this.Show();
            }
        }
    }
}
