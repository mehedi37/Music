using Microsoft.AspNetCore.Mvc;
using MVCTest.Interfaces;
using MVCTest.Models;

namespace MVCTest.Controllers
{
    public class ArtistController(IArtistRepo artistRepo) : Controller
    {
        private readonly IArtistRepo _artistRepo = artistRepo;
        public IActionResult Index()
        {
            var artists = _artistRepo.GetAll();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Artist artist)
        {   
            if (!ModelState.IsValid) {
                return View(artist);
            }
            _artistRepo.Add(artist);

            return RedirectToAction("Index");
        }
    }
}
