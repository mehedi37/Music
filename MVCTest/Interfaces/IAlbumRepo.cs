using MVCTest.Models;

namespace MVCTest.Interfaces
{
    public interface IAlbumRepo
    {
        Task<IEnumerable<Album>> GetAll();
        Task<IEnumerable<Artist>> GetAllArtists();
        Task<Album> GetById(int id);
        bool Add(Album album);
        bool Update(Album album); 
        bool DeleteAll();
        bool DeleteById(int id);
        bool Save();
    }
}
