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
    public class MethodsController : ControllerBase
    {
        private readonly DbCodingContext _context;

        public MethodsController(DbCodingContext context)
        {
            _context = context;
        }

        // GET: api/Methods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Method>>> GetMethods()
        {
            return await _context.Methods.ToListAsync();
        }

        // GET: api/Methods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Method>> GetMethod(int id)
        {
            var @method = await _context.Methods.FindAsync(id);

            if (@method == null)
            {
                return NotFound();
            }

            return @method;
        }

        // PUT: api/Methods/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMethod(int id, Method @method)
        {
            if (id != @method.Id)
            {
                return BadRequest();
            }

            _context.Entry(@method).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MethodExists(id))
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

        // POST: api/Methods
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Method>> PostMethod(Method @method)
        {
            _context.Methods.Add(@method);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMethod", new { id = @method.Id }, @method);
        }

        // DELETE: api/Methods/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Method>> DeleteMethod(int id)
        {
            var @method = await _context.Methods.FindAsync(id);
            if (@method == null)
            {
                return NotFound();
            }

            _context.Methods.Remove(@method);
            await _context.SaveChangesAsync();

            return @method;
        }

        private bool MethodExists(int id)
        {
            return _context.Methods.Any(e => e.Id == id);
        }
    }
}
