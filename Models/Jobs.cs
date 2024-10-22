using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiOnyx.Models
{
    public class Jobs
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Processing_Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? FinishedDateTime { get; set; }
        public DateTime ScheduledStartDateTime { get; set; }
        public DateTime ScheduledEndDateTime { get; set; }
        public string Assigned_Technician_Id { get; set; }
        public string Assigned_Customer_Id { get; set; }
        public double Total_Price { get; set; }
        public string InvoiceNumber { get; set; }
        public List<Item> JobInvoiceItems { get; set; }
        public int InvoiceId { get; internal set; }
        public string CompanyId { get; set; }
    }
}
