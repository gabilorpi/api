using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apibuscadores.Context;
using apibuscadores.Models;

namespace apibuscadores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoteisController : ControllerBase
    {
        private readonly DataContext _context;

        public HoteisController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Hoteis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hoteis>>> GetHoteis()
        {
            return await _context.Hoteis.ToListAsync();
        }

        // GET: api/Hoteis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hoteis>> GetHoteis(int id)
        {
            var hoteis = await _context.Hoteis.FindAsync(id);

            if (hoteis == null)
            {
                return NotFound();
            }

            return hoteis;
        }

        // PUT: api/Hoteis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoteis(int id, Hoteis hoteis)
        {
            if (id != hoteis.IdHotel)
            {
                return BadRequest();
            }

            _context.Entry(hoteis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoteisExists(id))
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

        // POST: api/Hoteis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hoteis>> PostHoteis(Hoteis hoteis)
        {
            _context.Hoteis.Add(hoteis);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHoteis", new { id = hoteis.IdHotel }, hoteis);
        }

        // DELETE: api/Hoteis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoteis(int id)
        {
            var hoteis = await _context.Hoteis.FindAsync(id);
            if (hoteis == null)
            {
                return NotFound();
            }

            _context.Hoteis.Remove(hoteis);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HoteisExists(int id)
        {
            return _context.Hoteis.Any(e => e.IdHotel == id);
        }
    }
}
