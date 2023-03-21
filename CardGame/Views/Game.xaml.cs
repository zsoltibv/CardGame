using CardGame.Controllers;
using CardGame.Models;
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

namespace CardGame.Views
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        private int _userId;
        private GameController _gameController;

        public Game(int id)
        {
            _userId = id;
            InitializeComponent();

            _gameController = new GameController();
            DataContext = _gameController;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            var buttonItem = (ButtonItem)((Button)sender).DataContext;
            _gameController.FlipItem(buttonItem, gameGrid);

            if (_gameController.CheckWin())
            {
                MessageBox.Show("You won.");
                return;
            }
        }

        private void ChangeBoardSize(object sender, RoutedEventArgs e)
        {
            ChangeBoard changeBoard = new ChangeBoard();
            bool? result = changeBoard.ShowDialog();

            if (result == true && changeBoard.GetRowCount()* changeBoard.GetColCount()%2==0)
            {
                _gameController.NrOfRows = changeBoard.GetRowCount();
                _gameController.NrOfCols = changeBoard.GetColCount();
                _gameController.LoadBoard();
                _gameController.ShuffleBoard();
            }
            else
            {
                MessageBox.Show("Loading board not possible. Nr of tiles is uneven.");
                return;
            }
        }

        private void ChangeBoardSizeToStandard(object sender, RoutedEventArgs e)
        {
            _gameController.NrOfRows = 4;
            _gameController.NrOfCols = 4;
            _gameController.LoadBoard();
            _gameController.ShuffleBoard();
        }

        private void SaveGame(object sender, RoutedEventArgs e)
        {
            _gameController.SaveGame(_userId);
        }
    }
}
