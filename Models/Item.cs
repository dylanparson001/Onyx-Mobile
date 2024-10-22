using System.ComponentModel.DataAnnotations;

namespace MauiOnyx.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int Category_Id { get; set; }
        public string Item_Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int DefaultQuantity { get; set; }
        public string CompanyId { get; set; }

    }
}