using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class Data
    {
        public List<List<string>> StringItems { get; set; }
        public Data() { 
            
            StringItems = new List<List<string>>();
            for(int i =0; i < 4; i++)
            {
                List<string> item = new List<string>();
                for(int j = 0; j<3; j++)
                {
                    item.Add("Str" + i + j);
                }
                StringItems.Add(item);
            }
        }
    }
}
