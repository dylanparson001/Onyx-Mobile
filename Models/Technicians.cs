using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MauiOnyx.Models
{
    public class Technicians : INotifyPropertyChanged
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CompanyId { get; set; }
        public double DailyTotal { get; set; }
        private List<Jobs> _todaysJobs;
        public List<Jobs> TodaysJobs
        {
            get => _todaysJobs;
            set
            {
                _todaysJobs = value;
                OnPropertyChanged(nameof(TodaysJobs));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
