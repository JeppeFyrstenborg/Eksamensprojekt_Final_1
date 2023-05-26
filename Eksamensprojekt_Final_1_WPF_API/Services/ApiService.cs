using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Eksamensprojekt_Final_1_WPF_API.Services
{
    public class ApiService
    {

        public string FetchData(string url)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            Task<string> task = client.GetStringAsync(url);
            var msg = task.Result;

            return msg;
        }
    }
}
