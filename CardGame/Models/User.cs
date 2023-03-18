using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CardGame.Models
{
    public class User
    {
        private static int _idCounter = 0;
        public int Id { get; private set; }
        public string Name { get; set; }

        public User(string name)
        {
            Id = Interlocked.Increment(ref _idCounter);
            Name = name;
        }
    }
}
