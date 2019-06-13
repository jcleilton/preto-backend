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
    [Route("api/faixa")]
    [ApiController]
    public class FaixaController : ControllerBase
    {
        private readonly FaixaContext _context;

        public FaixaController(FaixaContext context)
        {
            _context = context;
        }

        // GET: api/faixa
        [HttpGet]
        public IEnumerable<Faixa> GetFaixa()
        {
            return _context.FaixaObject;
        }

        // GET: api/faixa/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFaixa([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var faixa = await _context.FaixaObject.FindAsync(id);

            if (faixa == null)
            {
                return NotFound();
            }

            return Ok(faixa);
        }

        // PUT: api/faixa/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFaixa([FromRoute] int id, [FromBody] Faixa faixa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != faixa.id)
            {
                return BadRequest();
            }

            _context.Entry(faixa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FaixaExiste(id))
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

        // POST: api/faixa
        [HttpPost]
        public async Task<IActionResult> PostFaixa([FromBody] Faixa faixa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FaixaObject.Add(faixa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFaixa", new { id = faixa.id }, faixa);
        }

        // DELETE: api/faixa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaixa([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var faixa = await _context.FaixaObject.FindAsync(id);
            if (faixa == null)
            {
                return NotFound();
            }

            _context.FaixaObject.Remove(faixa);
            await _context.SaveChangesAsync();

            return Ok(faixa);
        }

        private bool FaixaExiste(int id)
        {
            return _context.FaixaObject.Any(e => e.id == id);
        }
    }
}