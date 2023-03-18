using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
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
            _userController = new UserController();
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;

            // Get the index of the selected item
            _selectedListIndex = listBox.SelectedIndex;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddUser(object sender, RoutedEventArgs e)
        {
            // Create a new instance of the UserWindow class (assuming you've created a Window class for entering user data)
            AddUser addUser = new AddUser();

            // Display the window modally
            bool? result = addUser.ShowDialog();

            // Check if the user clicked the "OK" button in the popup window
            if (result == true)
            {
                // Get the user data from the window and add it to the list of users
                _userController.AddUser(new User(addUser.GetUserName()));
            }
        }

        private void RemoveUser(object sender, RoutedEventArgs e)
        {
            //_userController.RemoveUser(_selectedListIndex);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
