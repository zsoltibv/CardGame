using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Controllers
{
    internal class GameController
    {
        public List<List<string>> StringItems { get; set; }
        public GameController() { 
            
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
