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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CardGame.Views
{
    /// <summary>
    /// Interaction logic for ChangeBoard.xaml
    /// </summary>
    public partial class ChangeBoard : Window
    {
        public ChangeBoard()
        {
            InitializeComponent();
        }

        public int GetRowCount()
        {
            return Convert.ToInt32(rowCount.Text);
        }

        public int GetColCount()
        {
            return Convert.ToInt32(colCount.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
