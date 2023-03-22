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
using CardGame.Controllers;

namespace CardGame.Views
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Window
    {
        public int UserId{get;set;}

        private UserController _userController;

        public Statistics(int userId)
        {
            UserId = userId;
            InitializeComponent();

            _userController = new UserController();
            gamesPlayed.Content = "Games Played: " + _userController.GetUser(UserId).GamesPlayed;
            gamesWon.Content = "Games Won: " + _userController.GetUser(UserId).GamesWon;
        }
    }
}
