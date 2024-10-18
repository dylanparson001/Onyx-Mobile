using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiOnyx.Services
{
    public interface IAlertService
    {
        void Alert(string message, string title, string cancel);
    }
    internal class AlertService : IAlertService
    {
        public void Alert(string message, string title, string cancel)
        {
             Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }
    }
}
