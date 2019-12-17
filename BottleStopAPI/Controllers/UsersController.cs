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
    [Route(ControllersName.userController)]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly BottleStopContext _context;

        public UsersController(BottleStopContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     Returns the username, user id, bottle size and balance. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("bottle/{id}")]
        public async Task<ActionResult<UserBottle>> GetUserBottle(string id)
        {
            UserBottle bottleUser = await _context.UserBottle
                .Where(bu => bu.BottleId == id)
                .Include(u => u.User)
                .Include(b => b.Bottle)
                    .ThenInclude(bm => bm.BottleModel)
                    .FirstOrDefaultAsync();

            if (bottleUser == null)
                return NotFound();

            bottleUser.User.Password = null;

            return bottleUser;
        }

        /// <summary>
        ///     Return beverages from favorites for users avaliable in machine.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("favorite/{id}/{machine}")]
        public async Task<ActionResult<IEnumerable<Favorite>>> GetFavorite(int id, string machine)
        {
            //List<MachineAvailability> machineAvailability = await _context.MachineAvailability
            //    .Where(m => m.MachineId == machine)
            //    .Include(b => b.Beverage)
            //    .ToListAsync();

            List <Favorite> favorite = await _context.Favorite
                .Where(u => u.UserId == id)
                .Include(u => u.User)
                .Include(b => b.Beverage)
                    .ThenInclude(b => b.MachineAvailability)
                .ToListAsync();

            if (favorite == null)
                return NotFound();

            return favorite;
        }
    }
}

