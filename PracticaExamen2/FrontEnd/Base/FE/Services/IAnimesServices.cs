using FE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FE.Services
{
    public interface IAnimesServices
    {
        void Insert(Anime t);
        void Update(Anime t);
        void Delete(Anime t);
        IEnumerable<Anime> GetAll();
        Anime GetOneById(int id);
        Task<IEnumerable<Anime>> GetAllAsync();
        Task<Anime> GetOneByIdAsync(int id);
    }
}
