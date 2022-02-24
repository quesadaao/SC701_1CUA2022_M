using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;


namespace DAL.Repository
{
    public class RepositoryProducts : Repository<data.Products>, IRepositoryProducts
    {

        public RepositoryProducts(NDbContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<data.Products>> GetAllAsync()
        {
            return await _db.Products
                .Include(m => m.Category)
                .ToListAsync();
        }

        public async Task<data.Products> GetOneByIdAsync(int id)
        {
            return await _db.Products
                .Include(m => m.Category)
                .SingleOrDefaultAsync(m => m.ProductId == id);
        }
        private NDbContext _db
        {
            get { return dbContext as NDbContext; }
        }
    }
}
