using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Framework
{
    public class WebClient
    {
        private readonly string _localUri = "http://localhost:50637/";
        public HttpClient Client { get; private set; }

        public WebClient()
        {
            Client = new HttpClient { BaseAddress = new Uri(_localUri) };
        }
        
        public async Task<string> GetContent(string uri)
        {
            var content = string.Empty;

            HttpResponseMessage response = await Client.GetAsync(uri);
            
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();
            }

            return content;
        }
    }
}