using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MinfinAnalog.Domain.Interfaces;
using MinfinAnalog.Domain.Models;

namespace MinfinAnalog.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        // GET: api/Users
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            _logger.LogWarning("called GetUsers"); // TODO remove this row
            return await _userService.GetUsers();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // TODO implement other methods by service di
        #region delete me
        //private readonly MinfinAnalogContext _context;

        //public UsersController(MinfinAnalogContext context, ILogger<UsersController> logger)
        //{
        //    _context = context;
        //    _logger = logger;
        //}

        //    // PUT: api/Users/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to, for
        //    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutUser(int id, User user)
        //    {
        //        if (id != user.Id)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(user).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UserExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        //    // POST: api/Users
        //    // To protect from overposting attacks, enable the specific properties you want to bind to, for
        //    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //    [HttpPost]
        //    public async Task<ActionResult<User>> PostUser(User user)
        //    {
        //        _context.Users.Add(user);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction("GetUser", new { id = user.Id }, user);
        //    }

        //    // DELETE: api/Users/5
        //    [HttpDelete("{id}")]
        //    public async Task<ActionResult<User>> DeleteUser(int id)
        //    {
        //        var user = await _context.Users.FindAsync(id);
        //        if (user == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Users.Remove(user);
        //        await _context.SaveChangesAsync();

        //        return user;
        //    }

        //    private bool UserExists(int id)
        //    {
        //        return _context.Users.Any(e => e.Id == id);
        //    }
        #endregion
    }
}
