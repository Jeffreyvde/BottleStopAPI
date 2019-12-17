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
                .ThenInclude(p => p.PumpPin)
                .ThenInclude(p => p.Pin)
                .ThenInclude(p => p.PinMode)
                .ToListAsync();
        }

        private bool MachineExists(string id)
        {
            return _context.Machine.Any(e => e.MachineId == id);
        }
    }
}
