using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinfinAnalog.Data;
using MinfinAnalog.Data.Entities;

namespace MinfinAnalog.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserWatchlistsController : ControllerBase
    {
        private readonly MinfinAnalogContext _context;

        public UserWatchlistsController(MinfinAnalogContext context)
        {
            _context = context;
        }

        // GET: api/UserWatchlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserWatchlist>>> GetUserWatchlists()
        {
            return await _context.UserWatchlists.ToListAsync();
        }

        // GET: api/UserWatchlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserWatchlist>> GetUserWatchlist(int id)
        {
            var userWatchlist = await _context.UserWatchlists.FindAsync(id);

            if (userWatchlist == null)
            {
                return NotFound();
            }

            return userWatchlist;
        }

        // PUT: api/UserWatchlists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserWatchlist(int id, UserWatchlist userWatchlist)
        {
            if (id != userWatchlist.Id)
            {
                return BadRequest();
            }

            _context.Entry(userWatchlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserWatchlistExists(id))
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

        // POST: api/UserWatchlists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserWatchlist>> PostUserWatchlist(UserWatchlist userWatchlist)
        {
            _context.UserWatchlists.Add(userWatchlist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserWatchlist", new { id = userWatchlist.Id }, userWatchlist);
        }

        // DELETE: api/UserWatchlists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserWatchlist>> DeleteUserWatchlist(int id)
        {
            var userWatchlist = await _context.UserWatchlists.FindAsync(id);
            if (userWatchlist == null)
            {
                return NotFound();
            }

            _context.UserWatchlists.Remove(userWatchlist);
            await _context.SaveChangesAsync();

            return userWatchlist;
        }

        private bool UserWatchlistExists(int id)
        {
            return _context.UserWatchlists.Any(e => e.Id == id);
        }
    }
}
