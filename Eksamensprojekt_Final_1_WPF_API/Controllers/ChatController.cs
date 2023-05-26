using Eksamensprojekt_Final_1_WPF_API.Models;
using Eksamensprojekt_Final_1_WPF_API.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows.Documents;

namespace Eksamensprojekt_Final_1_WPF_API.Controllers
{
    public class ChatController
    {
        private ApiService ApiService { get; }
        public ChatController()
        {
            this.ApiService = new ApiService();
        }

        public List<Chat> FetchAllChats()
        {
            List<Chat> _allChats = new List<Chat>();

            string _data = ApiService.FetchData("https://localhost:44336/api/chat/getAll");

            _allChats = JsonSerializer.Deserialize<List<Chat>>(_data);

            return _allChats;
        }

        public string UpdateChat(Chat chat)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonSerializer.Serialize(chat), Encoding.UTF8, "application/json");

                return client.PutAsync("https://localhost:44336/api/chat/UpdateChat", content).Result.Content.ReadAsStringAsync().Result;
            }
        }

        public string DeleteChat(int chatId)
        {
            using (HttpClient client = new HttpClient())
            {
                return client.DeleteAsync("https://localhost:44336/api/chat/deleteChat/" + chatId).Result.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
