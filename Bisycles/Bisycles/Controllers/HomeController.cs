using Bisycles.Models;
using Bisycles.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Bisycles.Models.BicyclesInteraction;
using Pag = Bisycles.Models.BicyclesInteraction.Pagination;
using Sort = Bisycles.Models.BicyclesInteraction.Sorting;
using Search = Bisycles.Models.BicyclesInteraction.Searching;
using Data = Bisycles.Models.BicyclesInteraction.StartData;
using Category = Bisycles.Models.BicyclesInteraction.Categories;
using Filter = Bisycles.Models.BicyclesInteraction.Filters;

namespace Bisycles.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        Singleton singleton = Singleton.getInstance();
        BicycleContext context;
        FilterBicyclesViewModel model;
        
        public HomeController(BicycleContext context)
        {
            model = new FilterBicyclesViewModel();
            this.context = context;
        }

        public IActionResult BicycleList(string filterCategory = "", string subcategory = "", int page = 1, string first = "true", string check = "check", string onlyPage = "false", string category = "", string search = "null")
        {
            if (first == "true")
            {
                singleton.FilterBicyclesViewModel = null;
            }

            if (onlyPage == "true")
            {
                model = singleton.FilterBicyclesViewModel;

                // переворот страницы
                model = Pag.TurnPage(page, model);
            }
            else if (category != "")
            {
                model = Sort.Sort(category, model);
            }
            else if(search != "null")
            {
                model = Search.Search(search, model);
            }
            else
            {
                if (singleton.FilterBicyclesViewModel != null)
                {
                    model = singleton.FilterBicyclesViewModel;
                    model.Pagination.CurrentPage = page;
                }
                else
                {
                    // начальные подсчеты
                    model = Data.GetFirstData(model, context);
                }

                if (check != "check")
                {
                    // добавление \ удаление категорий на фильтрацию
                    model = Category.CategoryToFilter(check, filterCategory, subcategory, model);
                }
                // отправка на фильтрацию
                model = Filter.Filter(model, context);

                //отфильтровка под пагинацию
                model = Pag.TurnPage(page, model);
                // подсчет категорий и действия с ними
                model = Category.WorkWithCategory(model);
            }

            //сохранение данных
            singleton.FilterBicyclesViewModel = model;

            return PartialView(model);
        }



        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.BicycleId = id;
            return View();
        }
        [HttpPost]
        public IActionResult Buy(Order order, int? id)
        {
            if (ModelState.IsValid)
            {
                order.BicycleId = id;
                context.Orders.Add(order);
                context.SaveChanges();

                EmailService emailService = new EmailService();
                emailService.SendEmailAsync($"{order.Email}", "Спасибо за покупку", "Гори в Аду!");

                return RedirectToAction("Index", new { message = "Спасибо за покупку. Горите в Аду!" });
            }
            else
            {
                return View(order);
            }
        }
        [HttpPost]
        public IActionResult NewPage(int pageNumber)
        {
            return RedirectToAction("Index", new { page = pageNumber });
        }
    }
}
