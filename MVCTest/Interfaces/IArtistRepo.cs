using MVCTest.Models;

namespace MVCTest.Interfaces
{
    public interface IArtistRepo
    {
        Task<IEnumerable<Artist>> GetAll();
        Task<Artist> GetById(int id);
        bool Add(Artist artist);
        bool Update(Artist artist); 
        bool DeleteAll();
        bool DeleteById(int id);
        bool Save();
    }
}
