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
    [Produces("application/json")]
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
        ///     Return favorite based on favorite id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("favorite/{id}")]
        public async Task<ActionResult<IEnumerable<Favorite>>> GetFavorite(int id)
        {
            List<Favorite> favorite = await _context.Favorite
                .Where(i => i.FavoriteId == id)
                .ToListAsync();

            if (favorite == null)
                return NotFound();

            return favorite;
        }

        /// <summary>
        ///     Returns the username, user id, bottle size and balance based on bottle. 
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

        /// IGNORE THIS!
        /// <summary>
        ///     Return users favorite beverages avaliable in machine.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("favorite/{uid}/{machine}")]
        public async Task<ActionResult<IEnumerable<Beverage>>> GetUserFavoriteBeverageFromMachine(int uid, string machine)
        {
            List <Beverage> beverage = await _context.Beverage
                .Include(f => f.Favorite)
                    .ThenInclude(u => u.User)
                .Include(ma => ma.MachineAvailability)
                .ToListAsync();

            if (beverage == null)
                return NotFound();

            return beverage;
        }

        /// <summary>
        ///     Add users favorite beverage
        /// </summary>
        /// <param name="favorite"></param>
        /// <returns></returns>
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("favorite/add")]
        public async Task<ActionResult<Favorite>> PostFavorite([FromBody]Favorite favorite)
        {
            _context.Favorite.Add(favorite);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFavorite), new { id = favorite.FavoriteId }, favorite);
        }

        /// <summary>
        ///     Delete favorite beverage
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("favorite/delete/{uid}/{bid}")]
        public async Task<ActionResult<IEnumerable<Favorite>>> DeleteFavorite(int uid, int bid)
        {
            List<Favorite> favorite = await _context.Favorite
                .Where(i => i.UserId == uid && i.BeverageId == bid)
                .ToListAsync();

            if (favorite == null)
            {
                return NotFound();
            }

            _context.Favorite.RemoveRange(favorite);
            await _context.SaveChangesAsync();

            return favorite;
        }
    }
}
