using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcessesAPI.Model;

namespace ProcessesAPI.Controllers
{
    [Route("api/evento")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly EventoContext _context;

        public EventoController(EventoContext context)
        {
            _context = context;
        }

        // GET: api/evento
        [HttpGet]
        public IEnumerable<Evento> GetEventos()
        {
            return _context.EventoObject;
        }

        // GET: api/evento/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var evento = await _context.EventoObject.FindAsync(id);

            if (evento == null)
            {
                return NotFound();
            }

            return Ok(evento);
        }

        // PUT: api/evento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento([FromRoute] int id, [FromBody] Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != evento.id)
            {
                return BadRequest();
            }

            _context.Entry(evento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExiste(id))
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

        // POST: api/evento
        [HttpPost]
        public async Task<IActionResult> PostEvento([FromBody] Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EventoObject.Add(evento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvento", new { id = evento.id }, evento);
        }

        // DELETE: api/categoria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var evento = await _context.EventoObject.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            _context.EventoObject.Remove(evento);
            await _context.SaveChangesAsync();

            return Ok(evento);
        }

        private bool EventoExiste(int id)
        {
            return _context.EventoObject.Any(e => e.id == id);
        }
    }
}