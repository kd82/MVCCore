using MvcCoreApplication.Entities;
using System.Collections.Generic;

namespace MvcCoreApplication.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
}
