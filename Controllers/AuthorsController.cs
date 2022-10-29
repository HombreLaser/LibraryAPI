using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Models;
using LibraryAPI.Filters;

namespace LibraryAPI.Controllers {
    [ServiceFilter(typeof(ActionFilter))]
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase {
        private readonly LibraryContext _context;

        public AuthorsController(LibraryContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors() {
            if(_context.Authors == null) {
                return NotFound();
            }

            return await _context.Authors.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(long id) {
            if(_context.Authors == null)
                return NotFound();

            var author = await _context.Authors.FindAsync(id);

            if(author == null)
                return NotFound();

            return author;
        }

        // Obtener los libros de un autor.
        [HttpGet("{id}/books")]
        public async Task<ActionResult<IEnumerable<Book>>> GetAuthorBooks(long id) {
            return await _context.Books.Where(x => x.AuthorId == id).ToListAsync();
        }

        // Obtener primer objeto de la tabla.
        [HttpGet("first")]
        public async Task<ActionResult<Author>> GetFirst() {
            return await _context.Authors.FirstOrDefaultAsync();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutAuthor(long id, Author author) {
            if(id != author.Id)
                return BadRequest("Attempted to modify a different resource");

            _context.Update(author);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author) {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthor(long id) {
            var author = await _context.Authors.FindAsync(id);

            if(author == null)
                return NotFound();

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
