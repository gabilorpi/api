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
    public class ContatosController : ControllerBase
    {
        private readonly DataContext _context;

        public ContatosController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Contatos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contatos>>> GetContatos()
        {
            return await _context.Contatos.ToListAsync();
        }

        // GET: api/Contatos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contatos>> GetContatos(int id)
        {
            var contatos = await _context.Contatos.FindAsync(id);

            if (contatos == null)
            {
                return NotFound();
            }

            return contatos;
        }

        // PUT: api/Contatos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContatos(int id, Contatos contatos)
        {
            if (id != contatos.IdContato)
            {
                return BadRequest();
            }

            _context.Entry(contatos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContatosExists(id))
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

        // POST: api/Contatos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contatos>> PostContatos(Contatos contatos)
        {
            _context.Contatos.Add(contatos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContatos", new { id = contatos.IdContato }, contatos);
        }

        // DELETE: api/Contatos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContatos(int id)
        {
            var contatos = await _context.Contatos.FindAsync(id);
            if (contatos == null)
            {
                return NotFound();
            }

            _context.Contatos.Remove(contatos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContatosExists(int id)
        {
            return _context.Contatos.Any(e => e.IdContato == id);
        }
    }
}
