using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LRN5.Models;

namespace LRN5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MethodArgumentsController : ControllerBase
    {
        private readonly DbCodingContext _context;

        public MethodArgumentsController(DbCodingContext context)
        {
            _context = context;
        }

        // GET: api/MethodArguments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MethodArgument>>> GetMethodArguments()
        {
            return await _context.MethodArguments.ToListAsync();
        }

        // GET: api/MethodArguments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MethodArgument>> GetMethodArgument(int id)
        {
            var methodArgument = await _context.MethodArguments.FindAsync(id);

            if (methodArgument == null)
            {
                return NotFound();
            }

            return methodArgument;
        }

        // PUT: api/MethodArguments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMethodArgument(int id, MethodArgument methodArgument)
        {
            if (id != methodArgument.Id)
            {
                return BadRequest();
            }

            _context.Entry(methodArgument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MethodArgumentExists(id))
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

        // POST: api/MethodArguments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MethodArgument>> PostMethodArgument(MethodArgument methodArgument)
        {
            _context.MethodArguments.Add(methodArgument);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMethodArgument", new { id = methodArgument.Id }, methodArgument);
        }

        // DELETE: api/MethodArguments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MethodArgument>> DeleteMethodArgument(int id)
        {
            var methodArgument = await _context.MethodArguments.FindAsync(id);
            if (methodArgument == null)
            {
                return NotFound();
            }

            _context.MethodArguments.Remove(methodArgument);
            await _context.SaveChangesAsync();

            return methodArgument;
        }

        private bool MethodArgumentExists(int id)
        {
            return _context.MethodArguments.Any(e => e.Id == id);
        }
    }
}
