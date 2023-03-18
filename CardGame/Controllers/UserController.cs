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
        private const string UsersFilePath = @"..\..\users.json";
        public ObservableCollection<User> AllUsers { get; set; }

        public UserController()
        {
            string jsonString = File.ReadAllText(UsersFilePath);
            if (jsonString == "")
            {
                File.WriteAllText(UsersFilePath, "[]");
                jsonString = File.ReadAllText(UsersFilePath);
            }

            // Deserialize the JSON data into a list of objects
            AllUsers = JsonSerializer.Deserialize<ObservableCollection<User>>(jsonString);
        }

        public void AddUser(User user)
        {
            AllUsers.Add(user);
            string json = JsonSerializer.Serialize(AllUsers);
            File.WriteAllText(UsersFilePath, json);
        }

        public void RemoveUser(int id)
        {
        }
    }
}