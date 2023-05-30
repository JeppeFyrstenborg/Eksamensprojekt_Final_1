using Eksamensprojekt_Final_1_WPF_API.Models;
using Eksamensprojekt_Final_1_WPF_API.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security;
using System.Text;
using System.Text.Json;

namespace Eksamensprojekt_Final_1_WPF_API.Controllers
{
    public class UserController
    {
        private Security Security { get; }
        private ApiService ApiService { get; }
        public UserController()
        {
            this.ApiService = new ApiService();
            this.Security = new Security();
        }

        public List<User> FetchAllUsers()
        {
            List<User> _allUsers = new List<User>();

            string _data = ApiService.FetchData("https://localhost:44336/api/user/getAll");

            _allUsers = JsonSerializer.Deserialize<List<User>>(_data);

            return _allUsers;
        }

        public HttpStatusCode DeleteUser(int userId)
        {
            using (HttpClient client = new HttpClient())
            {
                return client.DeleteAsync("https://localhost:44336/api/user/deleteuser/" + userId).Result.StatusCode;
            }
        }

        public HttpResponseMessage CreateUser(string username, string email, SecureString password, DateTime birthday)
        {
            using (HttpClient client = new HttpClient())
            {
                Tuple<string, string> passwordAndSalt = this.Security.GetHashedPasswordAndSaltFrom(password);

                User user = new User()
                {
                    Username = username,
                    Email = email,
                    Birthday = birthday
                };

                UserAuth userAuth = new UserAuth()
                {
                    HashedPassword = passwordAndSalt.Item1,
                    Salt = passwordAndSalt.Item2,
                    User = user
                };
                StringContent content = new StringContent(JsonSerializer
                    .Serialize(userAuth), Encoding.UTF8, "application/json");

                return client.PostAsync("https://localhost:44336/api/user/AddUser", content).Result;
            }

        }
    }
}
