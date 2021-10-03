using Bisycles.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pag = Bisycles.Models.BicyclesInteraction.Pagination;
using Sort = Bisycles.Models.BicyclesInteraction.Sorting;
using Search = Bisycles.Models.BicyclesInteraction.Searching;
using Data = Bisycles.Models.BicyclesInteraction.StartData;
using Category = Bisycles.Models.BicyclesInteraction.Categories;
using Filter = Bisycles.Models.BicyclesInteraction.Filters;

namespace Bisycles.Models.BicyclesInteraction
{
    public abstract class StartData
    {
        // получение начальных данных для сортировки
        public static void GetFirstSortData()
        {
            Singleton singleton = Singleton.getInstance();

            SortOptions sortOptions = new SortOptions();

            sortOptions.CategoryNameSortOption.Add("BicycleTitle", 1);
            sortOptions.CategoryNameSortOption.Add("BicycleFrameSize", 1);
            sortOptions.CategoryNameSortOption.Add("BicycleWheelDiameter", 1);
            sortOptions.CategoryNameSortOption.Add("BicycleColor", 1);
            sortOptions.CategoryNameSortOption.Add("BicycleNumberOfSpeeds", 1);
            sortOptions.CategoryNameSortOption.Add("BicycleManufactureCountry", 1);
            sortOptions.CategoryNameSortOption.Add("BicucleWeight", 1);
            sortOptions.CategoryNameSortOption.Add("BicyclePrice", 1);

            singleton.SortOptions = sortOptions;
        }

        // начальные подсчеты
        public static FilterBicyclesViewModel GetFirstData(FilterBicyclesViewModel model, BicycleContext context)
        {
            model.Pagination.CurrentPage = 1;
            model.Pagination.IntemsOnPage = 10;
            model.SelectedSpecifications.AllBicycles = context.Bicycle.ToList();
            model.Specifications.WeightMin = context.Bicycle.Min(x => x.BicucleWeight.ToString());
            model.Specifications.WeightMax = context.Bicycle.Max(x => x.BicucleWeight.ToString());
            model.Specifications.PriceMin = context.Bicycle.Min(x => x.BicyclePrice.ToString());
            model.Specifications.PriceMax = context.Bicycle.Max(x => x.BicyclePrice.ToString());
            model.Specifications.FrameSize.AddRange(context.Bicycle.Select(x => x.BicycleFrameSize.ToString()).Distinct());
            model.Specifications.WheelDiametr.AddRange(context.Bicycle.Select(x => x.BicycleWheelDiameter.ToString()).Distinct());
            model.Specifications.Color.AddRange(context.Bicycle.Select(x => x.BicycleColor).Distinct());
            model.Specifications.NumberOfSpeeds.AddRange(context.Bicycle.Select(x => x.BicycleNumberOfSpeeds.ToString()).Distinct());
            model.Specifications.Manufacturer.AddRange(context.Bicycle.Select(x => x.BicycleManufactureCountry.ToString()).Distinct());

            GetFirstSortData();

            return model;
        }



    }
}
