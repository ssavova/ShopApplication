using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.ViewModels.Home
{
    public class ItemsDetailsHomeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
