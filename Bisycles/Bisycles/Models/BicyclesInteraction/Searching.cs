using Bisycles.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pag = Bisycles.Models.BicyclesInteraction.Pagination;

namespace Bisycles.Models.BicyclesInteraction
{
    public abstract class Searching
    {

        // поиск
        public static FilterBicyclesViewModel Search(string search, FilterBicyclesViewModel model)
        {
            Singleton singleton = Singleton.getInstance();

            model = singleton.FilterBicyclesViewModel;

            List<Bicycle> bicycles = new List<Bicycle>();

            bicycles = (List<Bicycle>)model.SelectedSpecifications.AllBicycles.Where(x => x.BicycleTitle.ToLower().Contains(search.ToLower())).ToList();

            model.SelectedSpecifications.Bicycles = bicycles;

            model = Pag.TurnPage(model.Pagination.CurrentPage, model);

            return model;
        }


    }
}
