using Microsoft.EntityFrameworkCore;
using MVCTest.Data;
using MVCTest.Interfaces;
using MVCTest.Models; 


namespace MVCTest.Repository
{
    public class AlbumRepo(ApplicationDbContext context) : IAlbumRepo
    {
        private readonly ApplicationDbContext _context = context;
        public bool Add(Album album)
        {
            _context.Add(album);
            return Save();
        }

        public bool DeleteAll()
        {
            _context.RemoveRange(_context.Albums);
            return Save();
        }

        public bool DeleteById(int id)
        {
            _context.Remove(_context.Albums.Find(id));
            return Save();
        }

        public async Task<IEnumerable<Album>> GetAll()
        {
            return await _context.Albums.ToListAsync();
        }

        public async Task<Album> GetById(int id)
        {
            return await _context.Albums.FindAsync(id);
        }


        public bool Save()
        {
            var save = _context.SaveChanges();
            return (save > 0);
        }

        public bool Update(Album album)
        {
            _context.Update(album);
            return Save();
        }

        public async Task<IEnumerable<Artist>> GetAllArtists()
        {
            return await _context.Artists.ToListAsync();
        }

    }
}
