using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using System.Collections.Generic;
using CheeseMVC.ViewModels;
using CheeseMVC.Data;
using System.Linq;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        private CheeseDbContext context;
        
        public CheeseController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Cheese> cheeses = context.Cheeses.ToList();

            return View(cheeses);
        }

        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();
            return View(addCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                // Add the new cheese to my existing cheeses
                Cheese newCheese = AddCheeseViewModel.CreateCheese(addCheeseViewModel);                    

                context.Cheeses.Add(newCheese);
                context.SaveChanges();

                return Redirect("/Cheese");
            }

            return View(addCheeseViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheeses";
            ViewBag.cheeses = context.Cheeses.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            foreach (int cheeseId in cheeseIds)
            {
                Cheese theCheese = context.Cheeses.Single(c => c.ID == cheeseId);
                context.Cheeses.Remove(theCheese);
            }

            context.SaveChanges();

            return Redirect("/");
        }
        /*public IActionResult Edit(int cheeseId)
        {
            
             Cheese eCheese=CheeseData.GetById(cheeseId);
            EditViewCheeseModel editedCheese = new EditViewCheeseModel();

            editedCheese.Name = eCheese.Name;
            editedCheese.Description = eCheese.Description;
            editedCheese.Type = eCheese.Type;
            editedCheese.CheeseId = eCheese.CheeseId;
            

            return View(editedCheese);
        }
        [HttpPost]
        public IActionResult Edit(EditViewCheeseModel editedCheese)
        {
            Cheese editCheese = CheeseData.GetById(editedCheese.CheeseId);
            editCheese.Name = editedCheese.Name;
            editCheese.Description = editedCheese.Description;
            editCheese.Type = editedCheese.Type;
            return Redirect("/");
        }*/
    }
}
