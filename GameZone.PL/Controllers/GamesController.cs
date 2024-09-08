using BLL.Implamention;
using BLL.Interfaces;
using DAL.Data;
using DAL.Model;
using GameZone.PL.Hellper;
using GameZone.PL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.FileProviders;

namespace GameZone.PL.Controllers
{
    [Authorize]
    public class GamesController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public GamesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var Game = unitOfWork.GenreateRepositry<Game>().GetAll();
            return View(Game);
        }

        public IActionResult Add()
        {
            var GameViewMode = new CreateGameViewModel
            {
                Categorys = new SelectList(unitOfWork.GenreateRepositry<Category>().GetAll(), "Id", "Name"),
                Devices = new SelectList(unitOfWork.GenreateRepositry<Device>().GetAll(), "Id", "Name")
            };
            return View(GameViewMode);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CreateGameViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Image is null)
                {
                    ModelState.AddModelError("Image", "The image Is Requerid");
                    model.Devices = new SelectList(unitOfWork.GenreateRepositry<Device>().GetAll(), "Id", "Name");
                    model.Categorys = new SelectList(unitOfWork.GenreateRepositry<Category>().GetAll(), "Id", "Name");
                    return View(model);
                }

                var game = new Game {
                    Name = model.Name,
                    CategoryId = model.CategoryId,
                    Image = ImageSetting.UploadImage(model.Image, "Games"),
                    Devices = model.SelectedDevices.Select(d=> new GameDevice { DeviceId = d}).ToList(),
                    Description= model.Description,

       
                };

                unitOfWork.GenreateRepositry<Game>().Add(game);
                unitOfWork.IsComplite();
                return RedirectToAction(nameof(Index));

            }
            model.Devices = new SelectList (unitOfWork.GenreateRepositry<Device>().GetAll(),"Id" , "Name");
            model.Categorys = new SelectList (unitOfWork.GenreateRepositry<Category>().GetAll(),"Id", "Name");
            return View(model); 
        }

        public IActionResult Details (int id)
        {
            var game = unitOfWork.GenreateRepositry<Game>().GetById(id);
            if (game == null)
                return NotFound();
            return View (game); 
        }

        public IActionResult Edit(int id)
        {
            var Game = unitOfWork.GenreateRepositry<Game>().GetById(id);
            if (Game is null)
                return NotFound();
            var GameVM = new CreateGameViewModel()
            {
                Id = id,
                Name = Game.Name,
                CategoryId = Game.CategoryId,
                SelectedDevices = Game.Devices.Select(d => d.DeviceId).ToList(),
                Categorys = new SelectList(unitOfWork.GenreateRepositry<Category>().GetAll(), "Id", "Name"),
                Devices = new SelectList(unitOfWork.GenreateRepositry<Device>().GetAll(), "Id", "Name"),
                Description = Game.Description,
                ImageName = Game.Image
            };

            return View (GameVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CreateGameViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Image is not null)
                {
                    ImageSetting.DeleteImage("Games", model.ImageName);
                    model.ImageName = ImageSetting.UploadImage(model.Image, "Games");
                }
                var Game = unitOfWork.GenreateRepositry<Game>().GetById(model.Id);
                if (Game is null) return BadRequest();     
                Game.Name = model.Name;
                Game.Id = model.Id;
                Game.Description = model.Description;
                Game.CategoryId = model.CategoryId;
                Game.Devices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList();
                Game.Image = model.ImageName;
                
                unitOfWork.GenreateRepositry<Game>().Update(Game);
                return RedirectToAction("Index");
            }
            model.Devices = new SelectList(unitOfWork.GenreateRepositry<Device>().GetAll(), "Id", "Name");
            model.Categorys = new SelectList(unitOfWork.GenreateRepositry<Category>().GetAll(), "Id", "Name");
            return View (model);
        }

        public IActionResult Delete(int id)
        {
            var Game = unitOfWork.GenreateRepositry<Game>().GetById(id);
            if (Game is null)
                return NotFound();
            ImageSetting.DeleteImage("Games", Game.Image);

            unitOfWork.GenreateRepositry<Game>().Delete(Game);
            return RedirectToAction(nameof(Index));
        }
    }
}
