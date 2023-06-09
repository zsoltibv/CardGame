﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Models
{
    public class ButtonItem
    {
        public string ImageSource { get; set; }
        public string Visibility { get; set; } = "Hidden";
        public int Row { get;set; }
        public int Column { get; set; }

        public ButtonItem() { }

        public ButtonItem(ButtonItem buttonItem)
        {
            ImageSource = buttonItem.ImageSource;
            Visibility = buttonItem.Visibility;
            Row = buttonItem.Row;
            Column = buttonItem.Column;
        }

        public ButtonItem(ButtonItem buttonItem, int row, int column)
        {
            ImageSource = buttonItem.ImageSource;
            Visibility = buttonItem.Visibility;
            Row = row;
            Column = column;
        }
    }
}
