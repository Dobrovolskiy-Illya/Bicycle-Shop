using Bisycles.Models;
using Bisycles.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bisycles.Controllers
{
    [Authorize(Roles = "admin, super admin")]
    public class AdminController : Controller
    {
        BicycleContext context;
        private readonly UserManager<User> userManager;
        public AdminController (BicycleContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public IActionResult ListOfBicycles(int page = 1)
        {
            double maxPages = context.Bicycle.Count() / 10.0;
            ViewBag.Count = Math.Ceiling(maxPages);
            return View(context.Bicycle.Skip((int)(10 * (page - 1))).Take(10).ToList());
        }
        public IActionResult Create (int? id)
        {
            if (id == null)
            {
                return View();
            }
            else
            {
                var bicycleToEdit = context.Bicycle.Find(id);
                BicyclesViewModel model = new BicyclesViewModel
                {
                    BicycleTitle = bicycleToEdit.BicycleTitle,
                    BicycleFrameSize = bicycleToEdit.BicycleFrameSize,
                    BicycleWheelDiameter = bicycleToEdit.BicycleWheelDiameter,
                    BicycleColor = bicycleToEdit.BicycleColor,
                    BicycleNumberOfSpeeds = bicycleToEdit.BicycleNumberOfSpeeds,
                    BicycleManufactureCountry = bicycleToEdit.BicycleManufactureCountry,
                    BicucleWeight = bicycleToEdit.BicucleWeight,
                    BicyclePrice = bicycleToEdit.BicyclePrice
                };

                return View(model);
            }
        }

        public IActionResult Index()
        {
            return View();
        }


        private Bicycle AddOrCreateBicycle (Bicycle bicycle, BicyclesViewModel model)
        {
            string foto = null;
            if (model.AvatarAvatar != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(model.AvatarAvatar.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)model.AvatarAvatar.Length);
                }
                model.Avatar = imageData;
                foto = Convert.ToBase64String(model.Avatar);
            }


            bicycle.Avatar = foto;
            bicycle.BicucleWeight = model.BicucleWeight;
            bicycle.BicycleColor = model.BicycleColor;
            bicycle.BicycleFrameSize = model.BicycleFrameSize;
            bicycle.BicycleManufactureCountry = model.BicycleManufactureCountry;
            bicycle.BicycleNumberOfSpeeds = model.BicycleNumberOfSpeeds;
            bicycle.BicyclePrice = model.BicyclePrice;
            bicycle.BicycleTitle = model.BicycleTitle;
            bicycle.BicycleWheelDiameter = model.BicycleWheelDiameter;

            return bicycle;
        }


        [HttpPost]
        public IActionResult Create(BicyclesViewModel bicyclesViewModel, int? id)
        {
            if (ModelState.IsValid)
            {

                

                //убрать повторение кода
                // вынести в метод
                if (id == null)
                {
                    Bicycle bicycle = new Bicycle();
                    bicycle = AddOrCreateBicycle(bicycle, bicyclesViewModel);

                    {

                        //byte[] imageData = null;
                        //using (var binaryReader = new BinaryReader(bicyclesViewModel.AvatarAvatar.OpenReadStream()))
                        //{
                        //    imageData = binaryReader.ReadBytes((int)bicyclesViewModel.AvatarAvatar.Length);
                        //}
                        //bicyclesViewModel.Avatar = imageData;
                        //Bicycle bicycle = new Bicycle
                        //{
                        //    Avatar = Convert.ToBase64String(bicyclesViewModel.Avatar),
                        //    BicucleWeight = bicyclesViewModel.BicucleWeight,
                        //    BicycleColor = bicyclesViewModel.BicycleColor,
                        //    BicycleFrameSize = bicyclesViewModel.BicycleFrameSize,
                        //    BicycleManufactureCountry = bicyclesViewModel.BicycleManufactureCountry,
                        //    BicycleNumberOfSpeeds = bicyclesViewModel.BicycleNumberOfSpeeds,
                        //    BicyclePrice = bicyclesViewModel.BicyclePrice,
                        //    BicycleTitle = bicyclesViewModel.BicycleTitle,
                        //    BicycleWheelDiameter = bicyclesViewModel.BicycleWheelDiameter
                        //};
                    }
                    context.Bicycle.Add(bicycle);
                }
                else
                {
                    Bicycle bicycle = context.Bicycle.Find(id);


                    bicycle = AddOrCreateBicycle(bicycle, bicyclesViewModel);

                    {

                        //var bicycleToEdit = context.Bicycle.Find(bicyclesViewModel.BicycleId);


                        //byte[] imageData = null;
                        //using (var binaryReader = new BinaryReader(bicyclesViewModel.AvatarAvatar.OpenReadStream()))
                        //{
                        //    imageData = binaryReader.ReadBytes((int)bicyclesViewModel.AvatarAvatar.Length);
                        //}
                        //bicyclesViewModel.Avatar = imageData;

                        //bicycleToEdit.Avatar = Convert.ToBase64String(bicyclesViewModel.Avatar);
                        //bicycleToEdit.BicycleTitle = bicyclesViewModel.BicycleTitle;
                        //bicycleToEdit.BicycleFrameSize = bicyclesViewModel.BicycleFrameSize;
                        //bicycleToEdit.BicycleWheelDiameter = bicyclesViewModel.BicycleWheelDiameter;
                        //bicycleToEdit.BicycleColor = bicyclesViewModel.BicycleColor;
                        //bicycleToEdit.BicycleNumberOfSpeeds = bicyclesViewModel.BicycleNumberOfSpeeds;
                        //bicycleToEdit.BicycleManufactureCountry = bicyclesViewModel.BicycleManufactureCountry;
                        //bicycleToEdit.BicucleWeight = bicyclesViewModel.BicucleWeight;
                        //bicycleToEdit.BicyclePrice = bicyclesViewModel.BicyclePrice;

                    }
                }
                context.SaveChanges();
                return RedirectToAction("ListOfBicycles");
            }
            else
            {
                return View(bicyclesViewModel);
            }
        }

        [HttpPost]
        public IActionResult Delete (int bicycleId)
        {
            var bicycleToEdit = context.Bicycle.Find(bicycleId);
            context.Bicycle.Remove(bicycleToEdit);
            context.SaveChanges();
            return RedirectToAction("ListOfBicycles");
        }

        [HttpPost]
        public IActionResult NewPage(int pageNumber)
        {
            return RedirectToAction("ListOfBicycles", new { page = pageNumber });
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(RegisterViewModel model)
        {
            User user = new User { Email = model.Email, Year = model.Year, UserName = model.Email };
            IdentityResult result = await userManager.CreateAsync(user, model.Password);


            if (result.Succeeded)
            {
                User CurrentUser = await userManager.FindByNameAsync(user.UserName);
                if (user != null)
                {
                    List<string> roles = new List<string>();

                    if (userManager.Users.Count() == 1)
                    {
                        roles.Add("super admin");
                    }
                    else
                    {
                        roles.Add("guest");
                    }
                    await userManager.AddToRolesAsync(CurrentUser, roles);
                }
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            User user = await userManager.FindByIdAsync(userId);
            if (user != null)
            {
                if (User.Identity.Name == user.UserName)
                {
                    ModelState.AddModelError("", "Can`t be deleted, because you are admin!");
                }
                else
                {
                    await userManager.DeleteAsync(user);
                }
            }
            return RedirectToAction("UserList", "Roles");
        }
    }
}
