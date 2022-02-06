
using RMDesktopUI.Library.Model;
using RMDesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.Api
{
    public class APIHelper : IAPIHelper
    {
        private HttpClient _apiClient { get; set; }
        private ILoggedInUserModel _loggrdInUser;
        public APIHelper( ILoggedInUserModel loggedInUser)
        {
            InitiazeClient();
            _loggrdInUser = loggedInUser;
        }
        public HttpClient ApiClient
        {
            get
            {
                return _apiClient;
            }

        }
        private void InitiazeClient()
        {
            string api = ConfigurationManager.AppSettings["api"].ToString();
            _apiClient = new HttpClient();
            _apiClient.BaseAddress = new Uri(api);
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<AuthenticatedUser> Authenticate(string username, string password)
        {
            var data = new FormUrlEncodedContent(new[]
            {
             new KeyValuePair<string , string> ("grant_type" , "password"),
             new KeyValuePair<string , string> ("username" , username),
             new KeyValuePair<string , string> ("password" , password)
            });

            using (HttpResponseMessage responce = await _apiClient.PostAsync("/Token", data))
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

        public async Task GetLoggedInUserInfo(string token)
        {
            _apiClient.DefaultRequestHeaders.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _apiClient.DefaultRequestHeaders.Add("Authorization",$"Bearer { token}");
            using (HttpResponseMessage responce = await _apiClient.GetAsync("/api/User"))
            {
                if (responce.IsSuccessStatusCode)
                {
                    var result = await responce.Content.ReadAsAsync<LoggedInUserModel>();
                    _loggrdInUser.CreateDate = result.CreateDate;
                    _loggrdInUser.EmailAddress = result.EmailAddress;
                    _loggrdInUser.FirstName = result.FirstName;
                    _loggrdInUser.LastName = result.LastName;
                    _loggrdInUser.Id = result.Id;
                    _loggrdInUser.Token = token;
                }
                else
                {
                    throw new Exception(responce.ReasonPhrase);
                }
            
            

            }

        }
    }
}
