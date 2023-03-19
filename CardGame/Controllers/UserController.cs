using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Windows.Documents;
using CardGame.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace CardGame.Controllers
{
    internal class UserController
    {
        private const string _usersFilePath = "../../users.json";
        private const string _imagePathFormat = "../Images/ProfilePics/pic-{0}.png";
        public ObservableCollection<User> AllUsers { get; set; }

        public UserController()
        {
            string jsonString = File.ReadAllText(_usersFilePath);
            if (jsonString == "")
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
        }

        public User GetUser(int id)
        {
            return AllUsers[id];
        }

        public string GetNextImage(int id)
        {
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