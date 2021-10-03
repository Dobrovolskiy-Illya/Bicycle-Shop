using Bisycles.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bisycles.Models.BicyclesInteraction
{
    public abstract class Pagination
    {
        // переворот страници
        public static FilterBicyclesViewModel TurnPage(int page, FilterBicyclesViewModel model)
        {

            model.Pagination.CurrentPage = page;

            double maxPages = model.SelectedSpecifications.Bicycles.Count() / 10.0;
            model.Pagination.MaxPages = (int)Math.Ceiling(maxPages);
            model.Pagination.Bicycles = model.SelectedSpecifications.Bicycles
                .Skip((int)(model.Pagination.IntemsOnPage * (model.Pagination.CurrentPage - 1)))
                .Take(model.Pagination.IntemsOnPage).ToList();

            return model;
        }
    }
}
