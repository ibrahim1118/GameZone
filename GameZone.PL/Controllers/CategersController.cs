using BLL.Interfaces;
using DAL.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace GameZone.PL.Controllers
{
    [Authorize]
    public class CategersController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CategersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var Categers = unitOfWork.GenreateRepositry<Category>().GetAll();
            return View(Categers);
        }

        public IActionResult Add()
        {
            return View();  
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.GenreateRepositry<Category>().Add(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult Update(int id)
        {
            var cat = unitOfWork.GenreateRepositry<Category>().GetById(id);
            if (cat == null)
            {
               return NotFound();   
            }
            return View(cat);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Category category) 
        {
          if (ModelState.IsValid)
            {
                unitOfWork.GenreateRepositry<Category>().Update(category);
                return RedirectToAction(nameof(Index));
            }
          return View(category);
        }

        public IActionResult Delete(int id) {
            var cat = unitOfWork.GenreateRepositry<Category>().GetById(id); 
            if (cat is null)
                return NotFound();
            unitOfWork.GenreateRepositry<Category>().Delete(cat);
            return RedirectToAction(nameof(Index));
        
        }
    }
}
