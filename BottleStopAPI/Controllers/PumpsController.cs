using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BottleStopAPI.BottleStop;

namespace BottleStopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PumpsController : ControllerBase
    {
        private readonly BottleStopContext _context;

        public PumpsController(BottleStopContext context)
        {
            _context = context;
        }

        // GET: api/Pumps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pump>>> GetPump()
        {
            return await _context.Pump.ToListAsync();
        }

        // GET: api/Pumps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pump>> GetPump(int id)
        {
            var pump = await _context.Pump.FindAsync(id);

            if (pump == null)
            {
                return NotFound();
            }

            return pump;
        }

        // PUT: api/Pumps/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPump(int id, Pump pump)
        {
            if (id != pump.PumpId)
            {
                return BadRequest();
            }

            _context.Entry(pump).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PumpExists(id))
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

        // POST: api/Pumps
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Pump>> PostPump(Pump pump)
        {
            _context.Pump.Add(pump);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPump", new { id = pump.PumpId }, pump);
        }

        // DELETE: api/Pumps/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pump>> DeletePump(int id)
        {
            var pump = await _context.Pump.FindAsync(id);
            if (pump == null)
            {
                return NotFound();
            }

            _context.Pump.Remove(pump);
            await _context.SaveChangesAsync();

            return pump;
        }

        private bool PumpExists(int id)
        {
            return _context.Pump.Any(e => e.PumpId == id);
        }
    }
}
