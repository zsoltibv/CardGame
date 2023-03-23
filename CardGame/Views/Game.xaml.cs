using CardGame.Controllers;
using CardGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
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
        private UserController _userController;
        private TimeMeasure _timer;
        const int _timerSeconds = 180;

        public Game(int id, bool loadSavedGame)
        {
            _userId = id;
            InitializeComponent();

            //set user info
            _userController = new UserController();
            SetUserInfo();

            //set game info
            _gameController = new GameController
            {
                UserId = id,
            };

            if (loadSavedGame)
            {
                _gameController.LoadSavedGame();
                _timer = new TimeMeasure(_userController.GetTime(id));
                StartTimer();
            }
            else
            {
                _timer = new TimeMeasure(_timerSeconds);
                StartTimer();
            }
            DataContext = _gameController;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            var buttonItem = (ButtonItem)((Button)sender).DataContext;
            _gameController.FlipItem(buttonItem, gameGrid);

            if (_timer.RemainingTime.TotalSeconds > 0)
            {
                if (_gameController.CheckWin())
                {
                    _userController.IncreaseLevel(_userId);
                    _gameController.LoadBoard();
                    _gameController.ShuffleBoard();
                    SetUserInfo();
                    if (_userController.GetUser(_userId).CurrentLvl >= 3)
                    {
                        _timer.Stop();
                        MessageBox.Show("You won the game!");
                        _userController.IncreaseGamesPlayed(_userId);
                        _userController.IncreaseGamesWon(_userId);
                        _userController.ResetLevel(_userId);
                        SetUserInfo();
                    }
                }
            }

            else
            {
                _userController.IncreaseGamesPlayed(_userId);
                _userController.ResetLevel(_userId);
                SetUserInfo();
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
            _timer.Stop();
            _userController.GetUser(_userId).RemainingSeconds = _timer.RemainingTimeInSeconds;
            _userController.SaveToFile();

            _gameController.SaveGame();
        }

        private void NewGame(object sender, RoutedEventArgs e)
        {
            _gameController = new GameController
            {
                UserId = _userId
            };
            DataContext = _gameController;

            _userController.ResetLevel(_userId);
            SetUserInfo();

            //reset timer
            _timer = new TimeMeasure(_timerSeconds);
            StartTimer();
        }

        private void LoadGame(object sender, RoutedEventArgs e)
        {
            this.Close();
            Game game = new Game(_userId, true);
            game.ShowDialog();
        }

        private void SetUserInfo()
        {
            User currentUser = _userController.GetUser(_userId);
            playerName.Content = "Name: " + currentUser.Name;
            playerLvl.Content = "Level: " + currentUser.CurrentLvl;
            playerPic.Source = new BitmapImage(new Uri(_userController.GetCurrentImage(_userId),
                UriKind.Relative));
        }

        private void MainMenu(object sender, RoutedEventArgs e)
        {
            this.Hide();
            GameOptions gameOptions = new GameOptions(_userId);
            gameOptions.Show();
        }

        private void LoadStatistics(object sender, RoutedEventArgs e)
        {
            Statistics stats = new Statistics(_userId);
            stats.Show();
        }

        public async void StartTimer()
        {
            _timer.Start();
            playerTimer.Content = ("Remaining time: \n" + _timer.RemainingTime.ToString(@"mm\:ss"));

            while (_timer.RemainingTime.TotalSeconds > 0)
            {
                playerTimer.Content = ("Remaining time: \n" + _timer.RemainingTime.ToString(@"mm\:ss"));
                await Task.Delay(1000);
            }
            _timer.Stop();
            playerTimer.Content = ("Remaining time: \n" + _timer.RemainingTime.ToString(@"mm\:ss"));
            MessageBox.Show("Time Expired!");
        }

        private void LoadAbout(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
    }
}
