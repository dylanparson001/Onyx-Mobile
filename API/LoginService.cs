using MauiOnyx.Interfaces;
using MauiOnyx.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiOnyx.API
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _httpClient;
        public LoginService()
        {
            var apiUri = Preferences.Get("ApiUri", "");
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(apiUri),
            };
        }
        public async Task<User> Login(string username, string password, string companyId)
        {
            Login login = new Login()
            {
                Username = username,
                Password = password,
                CompanyId = companyId
            };

            var loginJson = JsonConvert.SerializeObject(login);
            var content = new StringContent(loginJson, Encoding.UTF8, "application/json");
            
            try
            {
                var response = await _httpClient.PostAsync("Authenticate/login", content);

                if (response.IsSuccessStatusCode)
                {
                    var stringContent = await response.Content.ReadAsStringAsync();

                    var user = JsonConvert.DeserializeObject<User>(stringContent);

                    return user;
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            return null;
        }
    }
}
