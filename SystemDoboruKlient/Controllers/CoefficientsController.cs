using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemDoboruKlient.Models;

namespace SystemDoboruKlient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoefficientsController : ControllerBase
    {
        private readonly BazaWentylatorowContext _context;

        public CoefficientsController(BazaWentylatorowContext context)
        {
            _context = context;
        }

        // GET: api/Coefficients
        [HttpGet]
        public IEnumerable<Coefficients> GetCoefficients()
        {
            return _context.Coefficients;
        }

        // GET: api/Coefficients/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoefficients([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coefficients = await _context.Coefficients.FindAsync(id);

            if (coefficients == null)
            {
                return NotFound();
            }

            return Ok(coefficients);
        }

        // PUT: api/Coefficients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoefficients([FromRoute] int id, [FromBody] Coefficients coefficients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coefficients.Id)
            {
                return BadRequest();
            }

            _context.Entry(coefficients).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoefficientsExists(id))
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

        // POST: api/Coefficients
        [HttpPost]
        public async Task<IActionResult> PostCoefficients([FromBody] Coefficients coefficients)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Coefficients.Add(coefficients);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoefficients", new { id = coefficients.Id }, coefficients);
        }

        // DELETE: api/Coefficients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoefficients([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coefficients = await _context.Coefficients.FindAsync(id);
            if (coefficients == null)
            {
                return NotFound();
            }

            _context.Coefficients.Remove(coefficients);
            await _context.SaveChangesAsync();

            return Ok(coefficients);
        }

        private bool CoefficientsExists(int id)
        {
            return _context.Coefficients.Any(e => e.Id == id);
        }
    }
}