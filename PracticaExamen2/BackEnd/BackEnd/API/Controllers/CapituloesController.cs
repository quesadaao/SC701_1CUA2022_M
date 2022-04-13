using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapituloesController : ControllerBase
    {
        private readonly AkiraToriyamaContext _context;

        public CapituloesController(AkiraToriyamaContext context)
        {
            _context = context;
        }

        // GET: api/Capituloes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Capitulo>>> GetCapitulo()
        {
            return await _context.Capitulo.ToListAsync();
        }

        // GET: api/Capituloes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Capitulo>> GetCapitulo(int id)
        {
            var capitulo = await _context.Capitulo.FindAsync(id);

            if (capitulo == null)
            {
                return NotFound();
            }

            return capitulo;
        }

        // PUT: api/Capituloes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCapitulo(int id, Capitulo capitulo)
        {
            if (id != capitulo.Id)
            {
                return BadRequest();
            }

            _context.Entry(capitulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CapituloExists(id))
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

        // POST: api/Capituloes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Capitulo>> PostCapitulo(Capitulo capitulo)
        {
            _context.Capitulo.Add(capitulo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCapitulo", new { id = capitulo.Id }, capitulo);
        }

        // DELETE: api/Capituloes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Capitulo>> DeleteCapitulo(int id)
        {
            var capitulo = await _context.Capitulo.FindAsync(id);
            if (capitulo == null)
            {
                return NotFound();
            }

            _context.Capitulo.Remove(capitulo);
            await _context.SaveChangesAsync();

            return capitulo;
        }

        private bool CapituloExists(int id)
        {
            return _context.Capitulo.Any(e => e.Id == id);
        }
    }
}
