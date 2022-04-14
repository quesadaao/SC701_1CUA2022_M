using FE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FE.Services
{
    public interface ITemporadasServices
    {
        void Insert(Temporada t);
        void Update(Temporada t);
        void Delete(Temporada t);
        IEnumerable<Temporada> GetAll();
        Temporada GetOneById(int id);
        Task<IEnumerable<Temporada>> GetAllAsync();
        Task<Temporada> GetOneByIdAsync(int id);
    }
}
