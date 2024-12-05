using CommunityToolkit.Mvvm.ComponentModel;
using MauiOnyx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiOnyx.ViewModels
{
    public class JobViewModel : ObservableObject
    {
        public Jobs currentJob { get; set; }
        public List<Item> _items { get; set; }
        
        public JobViewModel()
        {
            currentJob = new Jobs();
            _items = new List<Item>();
        }

        public async Task AddItemToJob(string itemName, int quantity)
        {
            if (string.IsNullOrEmpty(itemName))
            {
                throw new ArgumentNullException(nameof(itemName));
            }

            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity));
            }

            var itemToAdd = new Item()
            {
                Item_Name = itemName,
                Quantity = quantity
            };
            _items.Add(itemToAdd);

        }
    }
}
