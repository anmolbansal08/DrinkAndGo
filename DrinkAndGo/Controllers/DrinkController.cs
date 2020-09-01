using DrinkAndGo.Data.Interfaces;
using DrinkAndGo.Data.Models;
using DrinkAndGo.Data.Models.mocks;
using DrinkAndGo.ViewModels;
//using DrinkAndGo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DrinkAndGo.Controllers
{
    public class DrinkController:Controller
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IDrinkRepository _drinkRepository;
        //private readonly MockDrinkRepository MockDrinkRepository = new MockDrinkRepository();

        public DrinkController(IDrinkRepository drinkRepository, ICategoryRepository categoryRepository)
        {
            _drinkRepository = drinkRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List()

        {
            ViewBag.Name = "dotnet";
            var drinks = _drinkRepository.Drinks;
            DrinkListViewModel vm = new DrinkListViewModel();
            vm.Drinks=_drinkRepository.Drinks;
            vm.CurrentCategory = "DrinkCategory";
            return View(vm);

        }
    }
}
