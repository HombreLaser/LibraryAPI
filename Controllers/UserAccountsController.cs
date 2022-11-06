using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Models;
using LibraryAPI.Filters;

namespace LibraryAPI.Controllers {
    [Route("api/users")]
    [ApiController]
    public class UserAccountsController : ControllerBase {
        private readonly LibraryContext _context;

	public UserAccountsController(LibraryContext context) {
            _context = context;
        }

        [HttpPost("signup")]
	public async Task<ActionResult> PostUserAccount(UserAccount user) {
            _context.Add(user);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
