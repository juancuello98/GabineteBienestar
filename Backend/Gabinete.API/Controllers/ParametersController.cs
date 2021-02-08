using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gabinete.API.Models;

namespace Gabinete.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametersController : ControllerBase
    {
        private readonly ParemetersContext _context;

        public ParametersController(ParemetersContext context)
        {
            _context = context;
        }

        // GET: api/Parameters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parameters>>> GetParametros()
        {
            return await _context.Parametros.ToListAsync();
        }

        // GET: api/Parameters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parameters>> GetParameters(long id)
        {
            var parameters = await _context.Parametros.FindAsync(id);

            if (parameters == null)
            {
                return NotFound();
            }

            return parameters;
        }

        // PUT: api/Parameters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParameters(long id, Parameters parameters)
        {
            if (id != parameters.Id)
            {
                return BadRequest();
            }

            _context.Entry(parameters).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParametersExists(id))
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

        // POST: api/Parameters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Parameters>> PostParameters(Parameters parameters)
        {
            _context.Parametros.Add(parameters);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParameters", new { id = parameters.Id }, parameters);
        }

        // DELETE: api/Parameters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Parameters>> DeleteParameters(long id)
        {
            var parameters = await _context.Parametros.FindAsync(id);
            if (parameters == null)
            {
                return NotFound();
            }

            _context.Parametros.Remove(parameters);
            await _context.SaveChangesAsync();

            return parameters;
        }

        private bool ParametersExists(long id)
        {
            return _context.Parametros.Any(e => e.Id == id);
        }
    }
}
