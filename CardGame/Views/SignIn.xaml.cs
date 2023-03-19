using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CardGame.Controllers;
using CardGame.Models;

namespace CardGame.Views
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        private UserController _userController;
        private int _selectedUserId = -1;

        public SignIn()
        {
            InitializeComponent();

            _userController = new UserController();
            DataContext = _userController;
        }

        private void AddUser(object sender, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser();
            bool? result = addUser.ShowDialog();

            if (result == true)
            {
                _userController.AddUser(new User(addUser.GetUserName()));
            }
        }

        private void RemoveUser(object sender, RoutedEventArgs e)
        {
            _userController.RemoveUser(_selectedUserId);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = (ListView)sender;
            _selectedUserId = listView.SelectedIndex;

            profilePic.Source = new BitmapImage(new Uri(_userController.GetCurrentImage(_selectedUserId),
                UriKind.Relative));
        }

        private void NextImage(object sender, RoutedEventArgs e)
        {
            profilePic.Source = new BitmapImage(new Uri(_userController.GetNextImage(_selectedUserId), 
                UriKind.Relative));
        }

        private void PreviousImage(object sender, RoutedEventArgs e)
        {
            profilePic.Source = new BitmapImage(new Uri(_userController.GetPreviousImage(_selectedUserId),
               UriKind.Relative));
        }

        private void PlayGame(object sender, RoutedEventArgs e)
        {
            if(_selectedUserId != -1)
            {
                this.Hide();
                GameOptions options = new GameOptions(_selectedUserId);
                options.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a user in order to play.");
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
