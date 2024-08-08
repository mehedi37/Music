using Microsoft.EntityFrameworkCore;
using MVCTest.Data;
using MVCTest.Interfaces;
using MVCTest.Models;

namespace MVCTest.Repository
{
    public class ArtistRepo(ApplicationDbContext context) : IArtistRepo
    {
        private readonly ApplicationDbContext _context = context;
        public bool Add(Artist artist)
        {
            _context.Add(artist);
            return Save();
        }

        public bool DeleteAll()
        {
            _context.RemoveRange(_context.Artists);
            return Save();
        }

        public bool DeleteById(int id)
        {
            _context.Remove(_context.Artists.Find(id));
            return Save();
        }

        public async Task<IEnumerable<Artist>> GetAll()
        {
            return await _context.Artists.ToListAsync();
        }

        public async Task<Artist> GetById(int id)
        {
            return await _context.Artists.FindAsync(id);
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return (save > 0);
        }

        public bool Update(Artist artist)
        {
            _context.Update(artist);
            return Save();
        }
    }
}
