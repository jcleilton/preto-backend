using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcessesAPI.Model;

namespace ProcessesAPI.Controllers
{
    [Route("api/equipe")]
    [ApiController]
    public class EquipeController : ControllerBase
    {
        private readonly EquipeContext _context;

        public EquipeController(EquipeContext context)
        {
            _context = context;
        }

        // GET: api/equipe
        [HttpGet]
        public IEnumerable<Equipe> GetEquipes()
        {
            return _context.EquipeObject;
        }

        // GET: api/equipe/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEquipe([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var equipe = await _context.EquipeObject.FindAsync(id);

            if (equipe == null)
            {
                return NotFound();
            }

            return Ok(equipe);
        }

        // PUT: api/equipe/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipe([FromRoute] int id, [FromBody] Equipe equipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != equipe.id)
            {
                return BadRequest();
            }

            _context.Entry(equipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipeExiste(id))
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

        // POST: api/equipe
        [HttpPost]
        public async Task<IActionResult> PostEquipe([FromBody] Equipe equipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EquipeObject.Add(equipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipe", new { id = equipe.id }, equipe);
        }

        // DELETE: api/equipe/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipe([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var equipe = await _context.EquipeObject.FindAsync(id);
            if (equipe == null)
            {
                return NotFound();
            }

            _context.EquipeObject.Remove(equipe);
            await _context.SaveChangesAsync();

            return Ok(equipe);
        }

        private bool EquipeExiste(int id)
        {
            return _context.EquipeObject.Any(e => e.id == id);
        }
    }
}