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
    public class ProductsController : ControllerBase
    {
        private readonly NDbContext dbcontext;
        private readonly IMapper mapper;

        public ProductsController(NDbContext context, IMapper _mapper)
        {
            dbcontext = context;
            mapper = _mapper;
            }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Products>>> GetProducts()
        {
            var res = await new BS.Products(dbcontext).GetAllAsync();
            var mapaux = mapper.Map<IEnumerable<data.Products>, IEnumerable<models.Products>>(res).ToList();
            return mapaux;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Products>> GetProducts(int id)
        {
            var products = await new BS.Products(dbcontext).GetOneByIdAsync(id);
            var mapaux = mapper.Map<data.Products, models.Products>(products);

            if (products == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id, models.Products products)
        {
            if (id != products.ProductId)
            {
                return BadRequest();
            }

            try
            {                
                var mapaux = mapper.Map<models.Products, data.Products>(products);
                new BS.Products(dbcontext).Update(mapaux);
                }
            catch (Exception ee)
            {
                if (!ProductsExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Products>> PostProducts(models.Products products)
        {
            try
            {
                var mapaux = mapper.Map<models.Products, data.Products>(products);
                new BS.Products(dbcontext).Insert(mapaux);
                }
            catch (Exception)
            {
                BadRequest();
            }

            return CreatedAtAction("GetProducts", new { id = products.ProductId }, products);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Products>> DeleteProducts(int id)
        {
            var products = new BS.Products(dbcontext).GetOneById(id);
            var mapaux = mapper.Map<data.Products, models.Products>(products);
            if (products == null)
            {
                return NotFound();
            }

            try
            {
                new BS.Products(dbcontext).Delete(products);
            }
            catch (Exception)
            {
                BadRequest();
            }

            return mapaux;
        }

        private bool ProductsExists(int id)
        {
            return (new BS.Products(dbcontext).GetOneById(id) != null);
        }
    }
}
