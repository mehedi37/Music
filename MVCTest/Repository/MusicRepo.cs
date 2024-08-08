using Microsoft.EntityFrameworkCore;
using MVCTest.Data;
using MVCTest.Interfaces;
using MVCTest.Models;
using MVCTest.ViewModels;

namespace MVCTest.Repository
{
    public class MusicRepo(ApplicationDbContext context) : IMusicsRepo
    {
        private readonly ApplicationDbContext _context = context;
        public bool Add(Models.Musics musics)
        {
            _context.Add(musics);
            return Save();
        }

        public bool DeleteAll()
        {
            _context.RemoveRange(_context.Musics);
            return Save();
        }

        public bool DeleteById(int id)
        {
            _context.Remove(_context.Musics.Find(id));
            return Save();
        }

        public async Task<IEnumerable<Models.Musics>> GetAll()
        {
            return await _context.Musics
                .Include(m => m.Artist)
                .Include(a => a.Album)
                .ToListAsync();
        }

        public async Task<MusicCreateViewModel> AllAlbumNArtists()
        {
            var viewModel = new MusicCreateViewModel
            {
                Artists = await _context.Artists.ToListAsync(),
                Albums = await _context.Albums.ToListAsync()
            };
            return viewModel;
        }


        public bool Save()
        {
            var save = _context.SaveChanges();
            return (save > 0);
        }

        public bool Update(Models.Musics musics)
        {
            _context.Update(musics);
            return Save();
        }
    }
}
