using CardGame.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace CardGame.Controllers
{
    internal class GameController
    {
        private const string _imagePathFormat = "../Assets/CardPics/100-animal-flashcards-PACK-1-{0}.png";
        public ObservableCollection<List<ButtonItem>> ButtonItems { get; set; }
        private int NrOfRows { get; set; } = 4;
        private int NrOfCols { get; set; } = 4;
        List<ButtonItem> FlippedButtons { get; set; }

        private int _flippedCount = 0;

        public GameController()
        {
            ButtonItems = new ObservableCollection<List<ButtonItem>>();
            FlippedButtons = new List<ButtonItem> { };
            Random rand = new Random();

            for (int i = 0; i < NrOfRows; i++)
            {
                List<ButtonItem> button = new List<ButtonItem>();
                for (int j = 0; j < NrOfCols / 2; j++)
                {
                    int number = rand.Next(1, 100);
                    button.Add(new ButtonItem
                    {
                        ImageSource = string.Format(_imagePathFormat, number.ToString("D3")),
                        Row = i,
                        Column = j * 2,
                    });
                    button.Add(new ButtonItem
                    {
                        ImageSource = string.Format(_imagePathFormat, number.ToString("D3")),
                        Row = i,
                        Column = j * 2 + 1,
                    });
                }
                ButtonItems.Add(button);
            }
            ShuffleGrid();
        }

        public void ShuffleGrid()
        {
            //Fisher - Yates shuffle algorithm
            List<ButtonItem> flatArr = new List<ButtonItem>();

            for (int i = 0; i < NrOfRows; i++)
            {
                for (int j = 0; j < NrOfCols; j++)
                {
                    flatArr.Add(ButtonItems[i][j]);
                }
            }

            Random rand = new Random();
            for (int i = NrOfRows * NrOfCols - 1; i > 0; i--)
            {
                int j = rand.Next(0, i + 1);
                ButtonItem temp = new ButtonItem(flatArr[i]);
                flatArr[i] = flatArr[j];
                flatArr[j] = new ButtonItem(temp);
            }

            for (int i = 0; i < NrOfRows; i++)
            {
                for (int j = 0; j < NrOfCols; j++)
                {
                    ButtonItems[i][j] = new ButtonItem(flatArr[i * NrOfRows + j], i, j);
                }
            }
        }

        public async void FlipItem(int row, int col, ItemsControl gameGrid)
        {
            if (_flippedCount < 2)
            {
                ButtonItems[row][col].Visibility = "Visible";
                gameGrid.Items.Refresh();

                FlippedButtons.Add(ButtonItems[row][col]);
            }
            _flippedCount++;

            if (_flippedCount == 2)
            {
                await Task.Delay(500);

                if (FlippedButtons[0].ImageSource == FlippedButtons[1].ImageSource)
                {
                    FlippedButtons[0].Visibility = "Visible";
                    FlippedButtons[1].Visibility = "Visible";
                    gameGrid.Items.Refresh();
                }
                else
                {
                    FlippedButtons[0].Visibility = "Hidden";
                    FlippedButtons[1].Visibility = "Hidden";
                    gameGrid.Items.Refresh();
                }
                FlippedButtons.Clear();
                _flippedCount = 0;
            }
        }

        public bool CheckWin()
        {
            for(int i = 0; i < NrOfRows; i++)
            {
                for(int j = 0; j< NrOfCols; j++)
                {
                    if (ButtonItems[i][j].Visibility == "Hidden")
                        return false;
                }
            }
            return true;
        }
    }
}
