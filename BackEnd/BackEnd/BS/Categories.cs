using DAL.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
using dal = DAL;
using DAL.EF;

namespace BS
{
    public class Categories : ICRUD<data.Categories>
    {
        private dal.Categories _dal;
        public Categories(NDbContext dbContext)
        {
            _dal = new dal.Categories(dbContext);
        }
        public void Delete(data.Categories t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Categories> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Categories>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Categories GetOneById(int id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Categories> GetOneByIdAsync(int id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Categories t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Categories t)
        {
            _dal.Update(t);
        }
    }
}
