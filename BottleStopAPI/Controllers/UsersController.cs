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
        public async Task<ActionResult<IEnumerable<Beverage>>> GetFavorite(int id, string machine)
        {
            List <Beverage> beverage = await _context.Beverage
                .FromSqlRaw("select * " +
                "from beverage as b " +
                    "inner join favorite as f " +
                        "on b.beverage_id = f.beverage_id " +
                    "inner join `user` as u " +
                        "on f.user_id = u.user_id " +
                    "inner join machine_availability as ma " +
                        "on b.beverage_id = ma.beverage_id " +
                        "and ma.machine_id = {0} " +
                    "where u.user_id = {1}", machine, id)
                .ToListAsync();


            if (beverage == null)
                return NotFound();

            return beverage;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="beverage"></param>
        /// <param name="favorite"></param>
        /// <returns></returns>
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("/favorite/add")]
        public async Task<ActionResult<Favorite>> PostFavorite([FromBody]int user, int beverage)
        {
            var fav = new Favorite { UserId = user, BeverageId = beverage };
            _context.Favorite.Add(fav);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getfavorite", new { id = fav.BeverageId }, fav);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("/favorite/delete/{id}")]
        public async Task<ActionResult<Favorite>> DeleteFavorite(int id)
        {
            var favorite = await _context.Favorite.FindAsync(id);
            if (favorite == null)
            {
                return NotFound();
            }

            _context.Favorite.Remove(favorite);
            await _context.SaveChangesAsync();

            return favorite;
        }
    }
}

