using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Models;
using LibraryAPI.Filters;

namespace LibraryAPI.Controllers {
    [Route("api/groups")]
    [ApiController]
    public class GroupsController : ControllerBase {
	private readonly LibraryContext _context;

	public GroupsController(LibraryContext context) {
            _context = context;
        }

	[HttpPost]
	public async Task<ActionResult> PostGroup(Group g) {
            _context.Add(g);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
