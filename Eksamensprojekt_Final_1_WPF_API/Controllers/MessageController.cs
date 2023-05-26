using Eksamensprojekt_Final_1_WPF_API.Models;
using Eksamensprojekt_Final_1_WPF_API.Services;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows.Interop;

namespace Eksamensprojekt_Final_1_WPF_API.Controllers
{
    public class MessageController
    {
        private ApiService ApiService { get; }
        public MessageController()
        {
            this.ApiService = new ApiService();
        }

        public List<Message> FetchAllMessages()
        {
            List<Message> _allMessages = new List<Message>();

            string _data = ApiService.FetchData("https://localhost:44336/api/message/getAll");

            _allMessages = JsonSerializer.Deserialize<List<Message>>(_data);

            return _allMessages;
        }

    }
}
