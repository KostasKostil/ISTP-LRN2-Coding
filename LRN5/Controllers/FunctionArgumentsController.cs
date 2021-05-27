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
    public class FunctionArgumentsController : ControllerBase
    {
        private readonly DbCodingContext _context;

        public FunctionArgumentsController(DbCodingContext context)
        {
            _context = context;
        }

        // GET: api/FunctionArguments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FunctionArgument>>> GetFunctionArguments()
        {
            return await _context.FunctionArguments.ToListAsync();
        }

        // GET: api/FunctionArguments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FunctionArgument>> GetFunctionArgument(int id)
        {
            var functionArgument = await _context.FunctionArguments.FindAsync(id);

            if (functionArgument == null)
            {
                return NotFound();
            }

            return functionArgument;
        }

        // PUT: api/FunctionArguments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFunctionArgument(int id, FunctionArgument functionArgument)
        {
            if (id != functionArgument.Id)
            {
                return BadRequest();
            }

            _context.Entry(functionArgument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FunctionArgumentExists(id))
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

        // POST: api/FunctionArguments
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FunctionArgument>> PostFunctionArgument(FunctionArgument functionArgument)
        {
            _context.FunctionArguments.Add(functionArgument);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFunctionArgument", new { id = functionArgument.Id }, functionArgument);
        }

        // DELETE: api/FunctionArguments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FunctionArgument>> DeleteFunctionArgument(int id)
        {
            var functionArgument = await _context.FunctionArguments.FindAsync(id);
            if (functionArgument == null)
            {
                return NotFound();
            }

            _context.FunctionArguments.Remove(functionArgument);
            await _context.SaveChangesAsync();

            return functionArgument;
        }

        private bool FunctionArgumentExists(int id)
        {
            return _context.FunctionArguments.Any(e => e.Id == id);
        }
    }
}
