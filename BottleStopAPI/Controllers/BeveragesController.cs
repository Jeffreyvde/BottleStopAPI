using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BottleStopAPI.BottleStop;
using BottleStopAPI.Constants;

namespace BottleStopAPI.Controllers
{
    [Route(ControllersName.beverageController)]
    [ApiController]
    public class BeveragesController : ControllerBase
    {
        private readonly BottleStopContext _context;

        public BeveragesController(BottleStopContext context)
        {
            _context = context;
        }

        // GET: api/Beverages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beverage>>> GetBeverage()
        {
            List<Beverage> beverages = await _context.Beverage.ToListAsync();

            if (beverages == null)
                return NotFound();

            return beverages;
        }

        // GET: api/Beverages/{machine_id}
        /// <summary>
        ///     Gets available beverages for a specific machine
        /// </summary>
        /// <param name="'machine_id"></param>
        /// <returns></returns>
        [HttpGet("available/{machine_id}")]
        public async Task<ActionResult<IEnumerable<MachineAvailability>>> GetBeverageAvailability(string machine_id)
        {
            List <MachineAvailability> machineAvailability = await _context.MachineAvailability
                .Where(id => id.MachineId == machine_id)
                .Include(b => b.Beverage)             
                .ToListAsync();
                
            if (machineAvailability == null)
            {
                return NotFound();
            }

            return machineAvailability;
        }


        // GET: api/Beverages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Beverage>> GetBeverage(int id)
        {
            var beverage = await _context.Beverage.FindAsync(id);

            if (beverage == null)
            {
                return NotFound();
            }

            return beverage;
        }


        // GET: beverage/beverage ID/recipe
        /// <summary>
        /// This will return the recipe from the api
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/recipe")]
        public ActionResult<Recipe[]> GetBeverageRecipe(int id)
        {
            IQueryable<Recipe> beverages = _context.Recipe.Where(m => m.BeverageId == id)
            .Include(m => m.Ingredient);

            return beverages.ToArray();
        }

        // PUT: api/Beverages/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeverage(int id, Beverage beverage)
        {
            if (id != beverage.BeverageId)
            {
                return BadRequest();
            }

            _context.Entry(beverage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeverageExists(id))
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

        // POST: api/Beverages
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Beverage>> PostBeverage(Beverage beverage)
        {
            _context.Beverage.Add(beverage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBeverage", new { id = beverage.BeverageId }, beverage);
        }

        // DELETE: api/Beverages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Beverage>> DeleteBeverage(int id)
        {
            var beverage = await _context.Beverage.FindAsync(id);
            if (beverage == null)
            {
                return NotFound();
            }

            _context.Beverage.Remove(beverage);
            await _context.SaveChangesAsync();

            return beverage;
        }

        private bool BeverageExists(int id)
        {
            return _context.Beverage.Any(e => e.BeverageId == id);
        }
    }
}
