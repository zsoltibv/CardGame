using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
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
        public int ProfilePicNr {  get; set; }
        public int CurrentLvl { get; set; }
        public int GamesWon { get; set; }
        public int GamesPlayed { get; set; }
        public int RemainingSeconds { get; set; }

        public User(string name)
        {
            Id = Interlocked.Increment(ref _idCounter);
            Name = name;
            ProfilePicNr = 1;
            GamesPlayed = 0;
            GamesWon = 0;
            CurrentLvl = 1;
            RemainingSeconds = 0;
        }
    }
}
