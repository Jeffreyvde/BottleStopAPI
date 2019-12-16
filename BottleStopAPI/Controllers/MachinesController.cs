using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BottleStopAPI.BottleStop;

namespace BottleStopAPI.Controllers
{
    [Route(Constants.ControllersName.machinesController)]
    [ApiController]
    public class MachinesController : ControllerBase
    {
        private readonly BottleStopContext _context;

        public MachinesController(BottleStopContext context)
        {
            _context = context;
        }

        // GET: api/Machines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Machine>>> GetMachine()
        {
            return await _context.Machine.ToListAsync();
        }

        /// <summary>
        /// Get the availability for the machine
        /// </summary>
        /// <param name="id">the id for the machine</param>
        /// <returns></returns>
        // GET: machine/availability/id
        [HttpGet("availability/{id}")]
        public async Task<ActionResult<IEnumerable<MachineAvailability>>> GetMachineAvailability(string id)
        {
            return await _context.MachineAvailability
                .Where(m => m.MachineId == id)
                .Include(m => m.Beverage)
                .Include(m => m.Pump)
                .ToListAsync();
        }

        // PUT: api/Machines/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMachine(string id, Machine machine)
        {
            if (id != machine.MachineId)
            {
                return BadRequest();
            }

            _context.Entry(machine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineExists(id))
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

        // POST: api/Machines
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Machine>> PostMachine(Machine machine)
        {
            _context.Machine.Add(machine);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MachineExists(machine.MachineId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMachine", new { id = machine.MachineId }, machine);
        }

        // DELETE: api/Machines/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Machine>> DeleteMachine(string id)
        {
            var machine = await _context.Machine.FindAsync(id);
            if (machine == null)
            {
                return NotFound();
            }

            _context.Machine.Remove(machine);
            await _context.SaveChangesAsync();

            return machine;
        }

        private bool MachineExists(string id)
        {
            return _context.Machine.Any(e => e.MachineId == id);
        }
    }
}
