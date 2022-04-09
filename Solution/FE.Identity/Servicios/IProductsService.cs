using FE.Identity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FE.Identity.Servicios
{
    public interface IProductsService
    {
        void Insert(Products t);
        void Update(Products t);
        void Delete(Products t);
        IEnumerable<Products> GetAll();
        Products GetOneById(int id);
        Task<IEnumerable<Products>> GetAllAsync();
        Task<Products> GetOneByIdAsync(int id);
    }
}
