using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcessesAPI.Model;

namespace ProcessesAPI.Controllers
{
    [Route("api/competidor")]
    [ApiController]
    public class CompetidorController : ControllerBase
    {
        private readonly CompetidorContext _context;

        public CompetidorController(CompetidorContext context)
        {
            _context = context;
        }

        // GET: api/competidor
        [HttpGet]
        public IEnumerable<Competidor> GetCompetidores()
        {
            return _context.CompetidorObject;
        }

        // GET: api/competidor/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompetidor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var competidor = await _context.CompetidorObject.FindAsync(id);

            if (competidor == null)
            {
                return NotFound();
            }

            return Ok(competidor);
        }

        // PUT: api/competidor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompetidor([FromRoute] int id, [FromBody] Competidor competidor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != competidor.id)
            {
                return BadRequest();
            }

            _context.Entry(competidor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetidorExiste(id))
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

        // POST: api/competidor
        [HttpPost]
        public async Task<IActionResult> PostCompetidor([FromBody] Competidor competidor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CompetidorObject.Add(competidor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompetidor", new { id = competidor.id }, competidor);
        }

        // DELETE: api/competidor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompetidor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var competidor = await _context.CompetidorObject.FindAsync(id);
            if (competidor == null)
            {
                return NotFound();
            }

            _context.CompetidorObject.Remove(competidor);
            await _context.SaveChangesAsync();

            return Ok(competidor);
        }

        private bool CompetidorExiste(int id)
        {
            return _context.CompetidorObject.Any(e => e.id == id);
        }
    }
}