using BLL.Implamention;
using BLL.Interfaces;
using DAL.Model;
using GameZone.PL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameZone.PL.Controllers
{
 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
          
            var Games = unitOfWork.GenreateRepositry<Game>().GetAll();
            return View(Games);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}