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

        public Game(int id)
        {
            _userId = id;
            InitializeComponent();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            var buttonItem = (ButtonItem)((Button)sender).DataContext;
            int row = buttonItem.Row;
            int col = buttonItem.Column;
            // Do something with row and col
            Console.WriteLine("row: " + row.ToString() + ", col: " + col.ToString());
        }
    }
}
