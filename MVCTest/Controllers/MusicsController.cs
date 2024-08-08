using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCTest.Data;
using MVCTest.Interfaces;
using MVCTest.Models;
using MVCTest.ViewModels;

namespace MVCTest.Controllers
{
    public class MusicsController(IMusicsRepo musicsRepo, ApplicationDbContext context) : Controller
    {
        private readonly IMusicsRepo _musicsRepo = musicsRepo; 
        private readonly ApplicationDbContext _context = context;

        public async Task<IActionResult> Index()
        {
            IEnumerable<Musics> musics =  await _musicsRepo.GetAll();
            return View(musics);
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = await _musicsRepo.AllAlbumNArtists();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Musics musics)
        {
            if (!ModelState.IsValid)
            {
                return View(musics);
            }
            _musicsRepo.Add(musics);

            return RedirectToAction("Index");
        }
    }
}
