using Bisycles.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pag = Bisycles.Models.BicyclesInteraction.Pagination;

namespace Bisycles.Models.BicyclesInteraction
{
    public abstract class Sorting
    {



        



        // сортировка
        public static FilterBicyclesViewModel Sort(string category, FilterBicyclesViewModel model)
        {
            Singleton singleton = Singleton.getInstance();
            model = singleton.FilterBicyclesViewModel;

            model = SortItems.Sort(model, category);

            model = Pag.TurnPage(model.Pagination.CurrentPage, model);

            return model;
        }



    }
}
