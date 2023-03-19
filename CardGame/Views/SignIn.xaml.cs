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
        private int _selectedListIndex;

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
            _userController.RemoveUser(_selectedListIndex);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = (ListView)sender;
            _selectedListIndex = listView.SelectedIndex;

            profilePic.Source = new BitmapImage(new Uri(_userController.GetCurrentImage(_selectedListIndex),
                UriKind.Relative));
        }

        private void NextImage(object sender, RoutedEventArgs e)
        {
            profilePic.Source = new BitmapImage(new Uri(_userController.GetNextImage(_selectedListIndex), 
                UriKind.Relative));
        }

        private void PreviousImage(object sender, RoutedEventArgs e)
        {
            profilePic.Source = new BitmapImage(new Uri(_userController.GetPreviousImage(_selectedListIndex),
               UriKind.Relative));
        }

        private void PlayGame(object sender, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser();
            bool? result = addUser.ShowDialog();

            if (result == true)
            {
                _userController.AddUser(new User(addUser.GetUserName()));
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
