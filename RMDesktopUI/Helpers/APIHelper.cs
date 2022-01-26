using RMDesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.Helpers
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient ApiClient { get; set; }
        public APIHelper()
        {
            InitiazeClient();
        }
        private void InitiazeClient()
        {
            string api = ConfigurationManager.AppSettings["api"].ToString();
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri(api);
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<AuthenticatedUser> Authenticate(string username, string password)
        {
            var data = new FormUrlEncodedContent(new[]
            {
             new KeyValuePair<string , string> ("grant_type" , "password"),
             new KeyValuePair<string , string> ("username" , username),
             new KeyValuePair<string , string> ("password" , password)
            });

            using (HttpResponseMessage responce = await ApiClient.PostAsync("/Token", data))
            {
                if (responce.IsSuccessStatusCode)
                {
                    var result = await responce.Content.ReadAsAsync<AuthenticatedUser>();

                    return result;
                }
                else
                {
                    throw new Exception(responce.ReasonPhrase);
                }
            }
        }
    }
}
