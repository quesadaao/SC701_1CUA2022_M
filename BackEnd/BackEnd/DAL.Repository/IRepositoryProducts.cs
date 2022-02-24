using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;


namespace DAL.Repository
{
    public interface IRepositoryProducts : IRepository<data.Products>
    {
        Task<IEnumerable<data.Products>> GetAllAsync();
        Task<data.Products> GetOneByIdAsync(int id);
    }
}
