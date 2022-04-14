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
    public class TemporadasController : ControllerBase
    {
        private readonly AkiraToriyamaContext _context;

        public TemporadasController(AkiraToriyamaContext context)
        {
            _context = context;
        }

        // GET: api/Temporadas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Temporada>>> GetTemporada()
        {
            return await _context.Temporada.Include(c => c.IdAnimeNavigation).ToListAsync();
        }

        // GET: api/Temporadas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Temporada>> GetTemporada(int id)
        {
            var temporada = await _context.Temporada.FindAsync(id);

            if (temporada == null)
            {
                return NotFound();
            }

            return temporada;
        }

        // PUT: api/Temporadas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTemporada(int id, Temporada temporada)
        {
            if (id != temporada.Id)
            {
                return BadRequest();
            }

            _context.Entry(temporada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemporadaExists(id))
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

        // POST: api/Temporadas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Temporada>> PostTemporada(Temporada temporada)
        {
            _context.Temporada.Add(temporada);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTemporada", new { id = temporada.Id }, temporada);
        }

        // DELETE: api/Temporadas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Temporada>> DeleteTemporada(int id)
        {
            var temporada = await _context.Temporada.FindAsync(id);
            if (temporada == null)
            {
                return NotFound();
            }

            _context.Temporada.Remove(temporada);
            await _context.SaveChangesAsync();

            return temporada;
        }

        private bool TemporadaExists(int id)
        {
            return _context.Temporada.Any(e => e.Id == id);
        }
    }
}
