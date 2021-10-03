using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bisycles.Models.ViewModels
{
    public class FilterBicyclesViewModel
    {
        public BicyclesFilterSpecifications Specifications { get; set; }
        public BicyclesFilterSelectedSpecifications SelectedSpecifications { get; set; }
        public Pagination Pagination { get; set; }

        public FilterBicyclesViewModel()
        {
            Specifications = new BicyclesFilterSpecifications();
            SelectedSpecifications = new BicyclesFilterSelectedSpecifications();
            Pagination = new Pagination();
        }
    }
}

