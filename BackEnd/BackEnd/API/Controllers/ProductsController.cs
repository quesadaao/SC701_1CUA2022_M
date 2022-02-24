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
    public class ProductsController : ControllerBase
    {
        private readonly NDbContext dbcontext;

        public ProductsController(NDbContext context)
        {
            dbcontext = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            var res = new BS.Products(dbcontext).GetAll();
            return res.ToList();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProducts(int id)
        {
            var products = new BS.Products(dbcontext).GetOneById(id);

            if (products == null)
            {
                return NotFound();
            }

            return products;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id, Products products)
        {
            if (id != products.ProductId)
            {
                return BadRequest();
            }

            try
            {
                new BS.Products(dbcontext).Update(products);
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
        public async Task<ActionResult<Products>> PostProducts(Products products)
        {
            try
            {
                new BS.Products(dbcontext).Insert(products);
            }
            catch (Exception)
            {
                BadRequest();
            }

            return CreatedAtAction("GetProducts", new { id = products.ProductId }, products);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Products>> DeleteProducts(int id)
        {
            var products = new BS.Products(dbcontext).GetOneById(id);
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

            return products;
        }

        private bool ProductsExists(int id)
        {
            return (new BS.Products(dbcontext).GetOneById(id) != null);
        }
    }
}
