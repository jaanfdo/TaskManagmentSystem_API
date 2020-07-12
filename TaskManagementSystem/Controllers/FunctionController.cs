using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using DataAccess.Context;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunctionController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public FunctionController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Function
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tbl_genMasFunction>>> Gettbl_genMasFunction()
        {
            return await _context.tbl_genMasFunction.ToListAsync();
        }

        // GET: api/Function/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tbl_genMasFunction>> Gettbl_genMasFunction(string id)
        {
            var tbl_genMasFunction = await _context.tbl_genMasFunction.FindAsync(id);

            if (tbl_genMasFunction == null)
            {
                return NotFound();
            }

            return tbl_genMasFunction;
        }

        // PUT: api/Function/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttbl_genMasFunction(string id, tbl_genMasFunction tbl_genMasFunction)
        {
            if (id != tbl_genMasFunction.function_ID)
            {
                return BadRequest();
            }

            _context.Entry(tbl_genMasFunction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_genMasFunctionExists(id))
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

        // POST: api/Function
        [HttpPost]
        public async Task<ActionResult<tbl_genMasFunction>> Posttbl_genMasFunction(tbl_genMasFunction tbl_genMasFunction)
        {
            _context.tbl_genMasFunction.Add(tbl_genMasFunction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettbl_genMasFunction", new { id = tbl_genMasFunction.function_ID }, tbl_genMasFunction);
        }

        // DELETE: api/Function/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<tbl_genMasFunction>> Deletetbl_genMasFunction(string id)
        {
            var tbl_genMasFunction = await _context.tbl_genMasFunction.FindAsync(id);
            if (tbl_genMasFunction == null)
            {
                return NotFound();
            }

            _context.tbl_genMasFunction.Remove(tbl_genMasFunction);
            await _context.SaveChangesAsync();

            return tbl_genMasFunction;
        }

        private bool tbl_genMasFunctionExists(string id)
        {
            return _context.tbl_genMasFunction.Any(e => e.function_ID == id);
        }
    }
}
