using Bisycles.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filter = Bisycles.Models.BicyclesInteraction.Filters;




namespace Bisycles.Models.BicyclesInteraction
{
    public abstract class Categories
    {

        // добавление и удаление категории на фильтрации
        public static FilterBicyclesViewModel CategoryToFilter(string check, string filterCategory, string subcategory, FilterBicyclesViewModel model)
        {
            if (check == "true")
            {
                if (filterCategory == "AllFrameSize")
                {
                    model.SelectedSpecifications.AllFrameSize.Add(subcategory);
                }
                else if (filterCategory == "AllWheelDiameter")
                {
                    model.SelectedSpecifications.AllWheelDiameter.Add(subcategory);
                }
                else if (filterCategory == "AllColor")
                {
                    model.SelectedSpecifications.AllColor.Add(subcategory);
                }
                else if (filterCategory == "AllNumberOfSpeeds")
                {
                    model.SelectedSpecifications.AllNumberOfSpeeds.Add(subcategory);
                }
                else if (filterCategory == "AllManufactureCountry")
                {
                    model.SelectedSpecifications.AllManufactureCountry.Add(subcategory);
                }
            }
            else if (check == "false")
            {
                if (filterCategory == "AllFrameSize")
                {
                    model.SelectedSpecifications.AllFrameSize.Remove(subcategory);
                }
                else if (filterCategory == "AllWheelDiameter")
                {
                    model.SelectedSpecifications.AllWheelDiameter.Remove(subcategory);
                }
                else if (filterCategory == "AllColor")
                {
                    model.SelectedSpecifications.AllColor.Remove(subcategory);
                }
                else if (filterCategory == "AllNumberOfSpeeds")
                {
                    model.SelectedSpecifications.AllNumberOfSpeeds.Remove(subcategory);
                }
                else if (filterCategory == "AllManufactureCountry")
                {
                    model.SelectedSpecifications.AllManufactureCountry.Remove(subcategory);
                }
            }

            return model;
        }



        // подсчет категорий и действия с ними
        public static FilterBicyclesViewModel WorkWithCategory(FilterBicyclesViewModel model)
        {
            model = Filter.FilterCurrentSpecificationsGroupAndCount(model);
            model = Filter.FilterConstantSpecificationsCount(model);
            model = Filter.FiltersSpecificationsCount(model);

            return model;
        }



    }
}
