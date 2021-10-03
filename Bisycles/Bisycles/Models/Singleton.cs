using Bisycles.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bisycles.Models
{
    public class Singleton
    {
        private static Singleton instance;

        private FilterBicyclesViewModel filterBicyclesViewModel;
        private SortOptions sortOptions;
        private Singleton()
        { }

        public SortOptions SortOptions
        {
            get { return sortOptions; }
            set { sortOptions = value; }
        }

        public FilterBicyclesViewModel FilterBicyclesViewModel
        {
            get { return filterBicyclesViewModel; }
            set { filterBicyclesViewModel = value; }
        }

        public static Singleton getInstance()
        {
            if (instance == null)
                instance = new Singleton();
            return instance;
        }
    }
}
