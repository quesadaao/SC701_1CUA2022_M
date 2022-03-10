using DAL.DO.Objects;
using DAL.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using data = DAL.DO.Objects;
using models = API.DataModels;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly NDbContext dbcontext;
        private readonly IMapper mapper;

        public CategoriesController(NDbContext context, IMapper _mapper)
        {
            dbcontext = context;
            mapper = _mapper;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Categories>>> GetCategories()
        {
            //var res = new BS.Categories(dbcontext).GetAll().ToList();
            var res = new BS.Categories(dbcontext).GetAll();
            List<models.Categories> mapaux = mapper.Map<IEnumerable<data.Categories>, IEnumerable<models.Categories>>(res).ToList();
            return mapaux;
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Categories>> GetCategories(int id)
        {
            var categories = new BS.Categories(dbcontext).GetOneById(id);

            if (categories == null)
            {
                return NotFound();
            }
            var mapaux = mapper.Map<data.Categories, models.Categories>(categories);
            return mapaux;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategories(int id, models.Categories categories)
        {
            if (id != categories.CategoryId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.Categories, data.Categories>(categories);
                new BS.Categories(dbcontext).Update(mapaux);
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
        public async Task<ActionResult<models.Categories>> PostCategories(models.Categories categories)
        {
            try
            {
                var mapaux = mapper.Map<models.Categories, data.Categories>(categories);
                new BS.Categories(dbcontext).Insert(mapaux);
            }
            catch (Exception)
            {
                BadRequest();
            }

            return CreatedAtAction("GetCategories", new { id = categories.CategoryId }, categories);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Categories>> DeleteCategories(int id)
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
            var mapaux = mapper.Map<data.Categories, models.Categories>(categories);
            return mapaux;
        }

        private bool CategoriesExists(int id)
        {
            return (new BS.Categories(dbcontext).GetOneById(id)!=null);
        }
    }
}
