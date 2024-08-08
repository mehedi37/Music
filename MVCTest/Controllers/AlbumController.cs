using Microsoft.AspNetCore.Mvc;
using MVCTest.Data;
using MVCTest.Interfaces;
using MVCTest.Models;

namespace MVCTest.Controllers
{
    public class AlbumController(IAlbumRepo albumRepo) : Controller
    {
        private readonly IAlbumRepo _albumRepo = albumRepo;

        public async Task<IActionResult> Index()
        {
            IEnumerable<Artist> artists = await _albumRepo.GetAllArtists();
            return View(artists);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Album album)
        {
            if (!ModelState.IsValid)
            {
                return View(album);
            }
            _albumRepo.Add(album);

            return RedirectToAction("Index");
        }
    }
}
