using CardGame.Controllers;
using CardGame.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace CardGame.Views
{
    /// <summary>
    /// Interaction logic for GameOptions.xaml
    /// </summary>
    public partial class GameOptions : Window
    {
        private int _userId;

        public GameOptions(int id)
        {
            _userId = id;
            InitializeComponent();
            loadGameButton.IsEnabled = (File.Exists("../../Data/GameSaves/user" + _userId.ToString() + ".json"));
        }

        private void NewGame(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Game game = new Game(_userId, false);
            game.Show();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoadGame(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Game game = new Game(_userId, true);
            game.Show();
        }

        private void LoadStatistics(object sender, RoutedEventArgs e)
        {
            Statistics stats = new Statistics(_userId);
            stats.Show();
        }

        private void ChangeUser(object sender, RoutedEventArgs e)
        {
            this.Close();
            SignIn signIn = new SignIn();
            signIn.Show();
        }
    }
}
