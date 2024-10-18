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
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("http://192.168.1.26:5200/api/")
            };
        }
        public async Task<User> Login(string username, string password, string companyId)
        {
            var nullUser = new User();
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
            return nullUser;
        }
    }
}
