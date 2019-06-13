using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcessesAPI.Model;
using ProcessesAPI.Models;

namespace ProcessesAPI.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaContext _context;

        public CategoriaController(CategoriaContext context)
        {
            _context = context;
        }

        // GET: api/categoria
        [HttpGet]
        public IEnumerable<Categoria> GetCategoria()
        {
            return _context.CategoriaObject;
        }

        // GET: api/categoria/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoria([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoria = await _context.CategoriaObject.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        // PUT: api/categoria/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria([FromRoute] int id, [FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoria.id)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExiste(id))
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

        // POST: api/categoria
        [HttpPost]
        public async Task<IActionResult> PostCategoria([FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CategoriaObject.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoria", new { id = categoria.id }, categoria);
        }

        // DELETE: api/categoria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoria = await _context.CategoriaObject.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.CategoriaObject.Remove(categoria);
            await _context.SaveChangesAsync();

            return Ok(categoria);
        }

        private bool CategoriaExiste(int id)
        {
            return _context.CategoriaObject.Any(e => e.id == id);
        }
    }
}