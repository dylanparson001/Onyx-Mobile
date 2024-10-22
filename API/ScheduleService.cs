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
    public class ScheduleService : IScheduleService
    {
        private readonly HttpClient _httpClient;
        public ScheduleService()
        {
            string companyId = Preferences.Get("CompanyId", "");
            string token = Preferences.Get("Token", "");
            var apiUri = Preferences.Get("ApiUri", "");
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(apiUri),
            };

            if (!string.IsNullOrEmpty(companyId))
            {
                _httpClient.DefaultRequestHeaders.Add("CompanyId", companyId);
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            }

            if (!string.IsNullOrEmpty(token))
            {

            }
        }
        public async Task<List<Technicians>> GetAllFieldStaff()
        {
            var response = await _httpClient.GetAsync("User/GetAllTechnicians");

            response.EnsureSuccessStatusCode();
            string jsonResponse = await response.Content.ReadAsStringAsync();


            if (string.IsNullOrEmpty(jsonResponse))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<List<Technicians>>(jsonResponse);
        }

        public Task<List<Jobs>> GetTechnicianJobsByDate(string date, string technicianId)
        {
            throw new NotImplementedException();
        }
    }
}
