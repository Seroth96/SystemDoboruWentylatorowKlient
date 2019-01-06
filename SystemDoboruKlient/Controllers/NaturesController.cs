using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemDoboruKlient.Models;

namespace SystemDoboruKlient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NaturesController : ControllerBase
    {
        private readonly BazaWentylatorowContext _context;

        public NaturesController(BazaWentylatorowContext context)
        {
            _context = context;
        }

        // GET: api/Natures
        [EnableCors("MyPolicy")]
        public IEnumerable<Natures> GetNatures()
        {
            return _context.Natures;
        }

        // GET: api/Natures/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNatures([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var natures = await _context.Natures.FindAsync(id);

            if (natures == null)
            {
                return NotFound();
            }

            return Ok(natures);
        }

        // PUT: api/Natures/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNatures([FromRoute] int id, [FromBody] Natures natures)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != natures.Id)
            {
                return BadRequest();
            }

            _context.Entry(natures).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NaturesExists(id))
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

        // POST: api/Natures
        [HttpPost]
        public async Task<IActionResult> PostNatures([FromBody] Natures natures)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Natures.Add(natures);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNatures", new { id = natures.Id }, natures);
        }

        // DELETE: api/Natures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNatures([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var natures = await _context.Natures.FindAsync(id);
            if (natures == null)
            {
                return NotFound();
            }

            _context.Natures.Remove(natures);
            await _context.SaveChangesAsync();

            return Ok(natures);
        }

        private bool NaturesExists(int id)
        {
            return _context.Natures.Any(e => e.Id == id);
        }
    }
}