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
    }
}
