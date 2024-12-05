using CommunityToolkit.Mvvm.ComponentModel;
using MauiOnyx.Interfaces;
using MauiOnyx.Models;
using MauiOnyx.Pages;
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
        // Dictionary for techs and their jobs
        public ICommand LoadJobsCommand { get; set; }
        public ObservableCollection<Technicians> FieldStaff { get; set; }

        public ScheduleViewModel(IScheduleService scheduleService, IAlertService alertService)
        {
            _scheduleService = scheduleService;
            _alertService = alertService;
            FieldStaff = new ObservableCollection<Technicians>();

            LoadJobsCommand = new Command<string>(async (technicianId) => await NavigateToJobListPage(technicianId));
        }

        private async Task NavigateToJobListPage(string technicianId)
        {
            string test = "Test";

            await Shell.Current.GoToAsync($"{nameof(JobPage)}/{technicianId}");
        }

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
                throw;
            }
        }

        public async Task GetTechnicianJobs()
        {
            if (FieldStaff.Count == 0)
            {
                return;
            }

            try
            {
                foreach (var technician in FieldStaff)
                {
                    var todaysDate = DateTime.Now;
                    var listOfJobs = await _scheduleService.GetTechnicianJobsByDate(todaysDate.ToString(), technician.Id);

                    technician.TodaysJobs = listOfJobs.Where(x => x.Assigned_Technician_Id == technician.Id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
