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
    public class PaymentsController : ControllerBase
    {
        private readonly BottleStopContext _context;

        public PaymentsController(BottleStopContext context)
        {
            _context = context;
        }

        // GET: api/Payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Balance>>> GetBalance()
        {
            return await _context.Balance.ToListAsync();
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Balance>> GetBalance(int id)
        {
            var balance = await _context.Balance.FindAsync(id);

            if (balance == null)
            {
                return NotFound();
            }

            return balance;
        }

        // PUT: api/Payments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBalance(int id, Balance balance)
        {
            if (id != balance.BalanceId)
            {
                return BadRequest();
            }

            _context.Entry(balance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BalanceExists(id))
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

        // POST: api/Payments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Balance>> PostBalance(Balance balance)
        {
            _context.Balance.Add(balance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBalance", new { id = balance.BalanceId }, balance);
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Balance>> DeleteBalance(int id)
        {
            var balance = await _context.Balance.FindAsync(id);
            if (balance == null)
            {
                return NotFound();
            }

            _context.Balance.Remove(balance);
            await _context.SaveChangesAsync();

            return balance;
        }

        private bool BalanceExists(int id)
        {
            return _context.Balance.Any(e => e.BalanceId == id);
        }
    }
}
