using MauiOnyx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiOnyx.Interfaces
{
    public interface IScheduleService
    {
        public Task<List<Technicians>> GetAllFieldStaff();
        public Task<List<Jobs>> GetTechnicianJobsByDate(string date, string technicianId);
    }
}
