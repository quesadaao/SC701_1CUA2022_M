using data = DAL.DO.Objects;
using DAL.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;
using DAL.EF;

namespace DAL
{
    public class Categories : ICRUD<data.Categories>
    {
        private Repository<data.Categories> repo;
        public Categories(NDbContext dbContext)
        {
            repo = new Repository<data.Categories>(dbContext);
        }
        public void Delete(data.Categories t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Categories> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Categories>> GetAllAsync()
        {
            return null;
        }

        public data.Categories GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Categories> GetOneByIdAsync(int id)
        {
            return null;
        }

        public void Insert(data.Categories t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Categories t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
