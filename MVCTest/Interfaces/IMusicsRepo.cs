using MVCTest.Models;
using MVCTest.ViewModels;

namespace MVCTest.Interfaces
{
    public interface IMusicsRepo
    {
        Task<IEnumerable<Musics>> GetAll();
        Task<MusicCreateViewModel> AllAlbumNArtists();
        bool Add(Musics musics);
        bool Update(Musics musics); 
        bool DeleteAll();
        bool DeleteById(int id);
        bool Save();
    }
}
