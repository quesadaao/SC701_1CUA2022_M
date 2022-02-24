using DAL.DO.Objects;
using DAL.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly NDbContext dbcontext;

        public CategoriesController(NDbContext context)
        {
            dbcontext = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categories>>> GetCategories()
        {
            var res = new BS.Categories(dbcontext).GetAll().ToList();            
            return res;
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categories>> GetCategories(int id)
        {
            var categories = new BS.Categories(dbcontext).GetOneById(id);

            if (categories == null)
            {
                return NotFound();
            }

            return categories;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategories(int id, Categories categories)
        {
            if (id != categories.CategoryId)
            {
                return BadRequest();
            }

            try
            {
                new BS.Categories(dbcontext).Update(categories);
            }
            catch (Exception ee)
            {
                if (!CategoriesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Categories>> PostCategories(Categories categories)
        {
            try
            {
                new BS.Categories(dbcontext).Insert(categories);
            }
            catch (Exception)
            {
                BadRequest();
            }

            return CreatedAtAction("GetCategories", new { id = categories.CategoryId }, categories);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Categories>> DeleteCategories(int id)
        {
            var categories = new BS.Categories(dbcontext).GetOneById(id);
            if (categories == null)
            {
                return NotFound();
            }

            try
            {
                new BS.Categories(dbcontext).Delete(categories);
            }
            catch (Exception)
            {
                BadRequest();
            }

            return categories;
        }

        private bool CategoriesExists(int id)
        {
            return (new BS.Categories(dbcontext).GetOneById(id)!=null);
        }
    }
}