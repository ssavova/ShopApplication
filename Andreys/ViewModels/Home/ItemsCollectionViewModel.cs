using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.ViewModels.Home
{
    public class ItemsCollectionViewModel
    {
        public IEnumerable<ItemsDetailsHomeViewModel> Items { get; set; }
    }
}
