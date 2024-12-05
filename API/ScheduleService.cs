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
            var listOfTechnicians = JsonConvert.DeserializeObject<List<Technicians>>(jsonResponse);

            return listOfTechnicians;
        }

        public async Task<List<Jobs>> GetTechnicianJobsByDate(string date, string technicianId)
        {
            var resposne = await _httpClient.GetAsync($"Jobs/GetJobsByTechnician?date={date}&technicianId={technicianId}");

            resposne.EnsureSuccessStatusCode();
            string jsonResponse = await resposne.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(jsonResponse))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<List<Jobs>>(jsonResponse);
        }
    }
}
