using CommunityToolkit.Mvvm.ComponentModel;
using MauiOnyx.Interfaces;
using MauiOnyx.Models;
using MauiOnyx.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiOnyx.ViewModels
{
    public class ScheduleViewModel : ObservableObject
    {
        private readonly IScheduleService _scheduleService;
        private readonly IAlertService _alertService;

        public ICommand LoadJobsCommand { get; }
        public ObservableCollection<Technicians> FieldStaff { get; set; } = new ObservableCollection<Technicians>();


        public ScheduleViewModel(IScheduleService scheduleService, IAlertService alertService)
        {
            _scheduleService = scheduleService;
            _alertService = alertService;

            //LoadJobsCommand = new Command(LoadTechnicianJobs);

            LoadJobsCommand = new Command<string>(async (technicianId) => await NavigateToJobListPage(technicianId));
        }

        private async Task NavigateToJobListPage(string technicianId)
        {
            await Shell.Current.GoToAsync($"JobListPage?TechId={technicianId}");
        }

        //private async void LoadTechnicianJobs(object obj)
        //{
        //    await Shell.Current.GoToAsync($"JobListPage?TechId={}")
        //}

        public async Task GetFieldStaff()
        {
            try
            {
                var techs = await _scheduleService.GetAllFieldStaff();
                foreach (var tech in techs)
                {
                    tech.FullName = $"{tech.FirstName} {tech.LastName}";
                    FieldStaff.Add(tech);
                }
            }
            catch (Exception ex)
            {
                _alertService.Alert(ex.Message, "Error", "OK");
            }
        }

    }
}
