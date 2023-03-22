using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Windows.Documents;
using CardGame.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;

namespace CardGame.Controllers
{
    internal class UserController
    {
        private const string _usersFilePath = "../../Data/users.json";
        private const string _imagePathFormat = "../Assets/ProfilePics/pic-{0}.png";
        public ObservableCollection<User> AllUsers { get; set; }

        public UserController()
        {
            string jsonString;
            if (File.Exists(_usersFilePath))
            {
                jsonString = File.ReadAllText(_usersFilePath);
            }
            else
            {
                File.WriteAllText(_usersFilePath, "[]");
                jsonString = File.ReadAllText(_usersFilePath);
            }

            // Deserialize the JSON data into a list of objects
            AllUsers = JsonSerializer.Deserialize<ObservableCollection<User>>(jsonString);
        }

        public void AddUser(User user)
        {
            AllUsers.Add(user);
            SaveToFile();
        }

        public void RemoveUser(int id)
        {
            AllUsers.RemoveAt(id);
            SaveToFile();

            //delete saved games file
            string file = "../../Data/GameSaves/user" + id.ToString() + ".json";
            if (File.Exists(file))
            {
                File.Delete(file);
                Console.WriteLine("File deleted successfully.");
            }
        }

        public User GetUser(int id)
        {
            return AllUsers[id];
        }

        public TimeMeasure GetTimer(int id)
        {
            return AllUsers[id].Timer;
        }

        public void IncreaseLevel(int id)
        {
            AllUsers[id].CurrentLvl++;
            SaveToFile();
        }

        public void IncreaseGamesPlayed(int id)
        {
            AllUsers[id].GamesPlayed++;
            SaveToFile();
        }

        public void IncreaseGamesWon(int id)
        {
            AllUsers[id].GamesWon++;
            SaveToFile();
        }

        public void ResetLevel(int id)
        {
            AllUsers[id].CurrentLvl = 0;
            SaveToFile();
        }

        public string GetNextImage(int id)
        {
            if (AllUsers.Count == 0)
            {
                MessageBox.Show("No player exists.");
                return GetCurrentImage(1);
            }

            if (AllUsers[id].ProfilePicNr == 6)
            {
                AllUsers[id].ProfilePicNr = 1;
            }
            else
            {
                AllUsers[id].ProfilePicNr++;
            }
            SaveToFile();
            return GetCurrentImage(id);
        }

        public string GetPreviousImage(int id)
        {
            if (AllUsers.Count == 0)
            {
                MessageBox.Show("No player exists.");
                return GetCurrentImage(1);
            }

            if (AllUsers[id].ProfilePicNr == 1)
            {
                AllUsers[id].ProfilePicNr = 6;
            }
            else
            {
                AllUsers[id].ProfilePicNr--;
            }
            SaveToFile();
            return GetCurrentImage(id);
        }

        public string GetCurrentImage(int id)
        {
            if (id != -1)
            {
                return string.Format(_imagePathFormat, AllUsers[id].ProfilePicNr);
            }
            return string.Format(_imagePathFormat, 1);
        }

        public void SaveToFile()
        {
            string json = JsonSerializer.Serialize(AllUsers);
            File.WriteAllText(_usersFilePath, json);
        }
    }
}