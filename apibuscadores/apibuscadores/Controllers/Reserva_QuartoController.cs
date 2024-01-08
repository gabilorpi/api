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
    public class Reserva_QuartoController : ControllerBase
    {
        private readonly DataContext _context;

        public Reserva_QuartoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Reserva_Quarto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reserva_Quarto>>> GetReserva_Quarto()
        {
            return await _context.Reserva_Quarto.ToListAsync();
        }

        // GET: api/Reserva_Quarto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reserva_Quarto>> GetReserva_Quarto(int id)
        {
            var reserva_Quarto = await _context.Reserva_Quarto.FindAsync(id);

            if (reserva_Quarto == null)
            {
                return NotFound();
            }

            return reserva_Quarto;
        }

        // PUT: api/Reserva_Quarto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReserva_Quarto(int id, Reserva_Quarto reserva_Quarto)
        {
            if (id != reserva_Quarto.IdReserva)
            {
                return BadRequest();
            }

            _context.Entry(reserva_Quarto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Reserva_QuartoExists(id))
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

        // POST: api/Reserva_Quarto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reserva_Quarto>> PostReserva_Quarto(Reserva_Quarto reserva_Quarto)
        {
            _context.Reserva_Quarto.Add(reserva_Quarto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReserva_Quarto", new { id = reserva_Quarto.IdReserva }, reserva_Quarto);
        }

        // DELETE: api/Reserva_Quarto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserva_Quarto(int id)
        {
            var reserva_Quarto = await _context.Reserva_Quarto.FindAsync(id);
            if (reserva_Quarto == null)
            {
                return NotFound();
            }

            _context.Reserva_Quarto.Remove(reserva_Quarto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Reserva_QuartoExists(int id)
        {
            return _context.Reserva_Quarto.Any(e => e.IdReserva == id);
        }
    }
}
