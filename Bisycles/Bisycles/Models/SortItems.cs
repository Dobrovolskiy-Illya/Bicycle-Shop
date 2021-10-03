using Bisycles.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bisycles.Models
{
    public static class SortItems
    {
        public static FilterBicyclesViewModel Sort (FilterBicyclesViewModel model, string sortType)
        {
            Singleton singleton = Singleton.getInstance();

            SortOptions sortOptions = singleton.SortOptions;


            List<Bicycle> bicycles = new List<Bicycle>();
            switch (sortType)
            {
                case "BicycleTitle":
                    bicycles = (sortOptions.CategoryNameSortOption["BicycleTitle"] == 1) ?
                        model.SelectedSpecifications.Bicycles.OrderBy(x => x.BicycleTitle).ToList() :
                        model.SelectedSpecifications.Bicycles.OrderByDescending(x => x.BicycleTitle).ToList();
                    break;
                case "BicycleFrameSize":
                    bicycles = (sortOptions.CategoryNameSortOption["BicycleFrameSize"] == 1) ?
                        model.SelectedSpecifications.Bicycles.OrderBy(x => x.BicycleFrameSize).ToList() :
                        model.SelectedSpecifications.Bicycles.OrderByDescending(x => x.BicycleFrameSize).ToList();
                    break;
                case "BicycleWheelDiameter":
                    bicycles = (sortOptions.CategoryNameSortOption["BicycleWheelDiameter"] == 1) ?
                        model.SelectedSpecifications.Bicycles.OrderBy(x => x.BicycleWheelDiameter).ToList() :
                        model.SelectedSpecifications.Bicycles.OrderByDescending(x => x.BicycleWheelDiameter).ToList();
                    break;
                case "BicycleColor":
                    bicycles = (sortOptions.CategoryNameSortOption["BicycleColor"] == 1) ?
                        model.SelectedSpecifications.Bicycles.OrderBy(x => x.BicycleColor).ToList() :
                        model.SelectedSpecifications.Bicycles.OrderByDescending(x => x.BicycleColor).ToList();
                    break;
                case "BicycleNumberOfSpeeds":
                    bicycles = (sortOptions.CategoryNameSortOption["BicycleNumberOfSpeeds"] == 1) ?
                        model.SelectedSpecifications.Bicycles.OrderBy(x => x.BicycleNumberOfSpeeds).ToList() :
                        model.SelectedSpecifications.Bicycles.OrderByDescending(x => x.BicycleNumberOfSpeeds).ToList();
                    break;
                case "BicycleManufactureCountry":
                    bicycles = (sortOptions.CategoryNameSortOption["BicycleManufactureCountry"] == 1) ?
                        model.SelectedSpecifications.Bicycles.OrderBy(x => x.BicycleManufactureCountry).ToList() :
                        model.SelectedSpecifications.Bicycles.OrderByDescending(x => x.BicycleManufactureCountry).ToList();
                    break;
                case "BicucleWeight":
                    bicycles = (sortOptions.CategoryNameSortOption["BicucleWeight"] == 1) ?
                        model.SelectedSpecifications.Bicycles.OrderBy(x => x.BicucleWeight).ToList() :
                        model.SelectedSpecifications.Bicycles.OrderByDescending(x => x.BicucleWeight).ToList();
                    break;
                case "BicyclePrice":
                    bicycles = (sortOptions.CategoryNameSortOption["BicyclePrice"] == 1) ?
                        model.SelectedSpecifications.Bicycles.OrderBy(x => x.BicyclePrice).ToList() :
                        model.SelectedSpecifications.Bicycles.OrderByDescending(x => x.BicyclePrice).ToList();
                    break;
            }


            ChangeDictionary(sortOptions, sortType);
            singleton.SortOptions = sortOptions;

            model.SelectedSpecifications.Bicycles = bicycles;


            return model;
        }

        private static SortOptions ChangeDictionary (SortOptions sortOptions, string category)
        {
            if (sortOptions.CategoryNameSortOption[category] == 1)
            {
                sortOptions.CategoryNameSortOption[category] = 2;
            }
            else
            {
                sortOptions.CategoryNameSortOption[category] = 1;
            }

            return sortOptions;
        }
    }
}
