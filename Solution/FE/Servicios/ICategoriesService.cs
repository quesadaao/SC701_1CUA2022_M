namespace FE.Servicios
{
    using FE.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
        void Insert(Categories t);
        void Update(Categories t);
        void Delete(Categories t);
        IEnumerable<Categories> GetAll();
        Categories GetOneById(int id);
        Task<IEnumerable<Categories>> GetAllAsync();
        Task<Categories> GetOneByIdAsync(int id);
    }
}
