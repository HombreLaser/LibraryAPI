using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Models;
using LibraryAPI.Filters;

namespace LibraryAPI.Controllers {
    [ServiceFilter(typeof(ActionFilter))]
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context) {
            _context = context;
        }

        /* Listar todos los libros.
           o, regresar el que tenga un título específico */
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks() {
            return await _context.Books.ToListAsync();
        }

        // Obtener el primer libro de la tabla.
        [HttpGet("first")]
        public async Task<ActionResult<Book>> GetFirst() {
            return await _context.Books.FirstOrDefaultAsync();
        }

        // Obtener un libro por isbn.
        [HttpGet("{isbn}")]
        public async Task<ActionResult<Book>> GetBook([FromRoute] string isbn) {
            var book = await _context.Books.FirstOrDefaultAsync(x => x.ISBN == isbn);

            if(book == null)
                return NotFound();
        
            return book;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> GetBook(long id) {
            if (_context.Books == null)
                return NotFound();

            var book = await _context.Books.FindAsync(id);

            if (book == null)
                return NotFound();

            return book;
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> PutBook(long id, Book book) {
            if (id != book.Id)
                return BadRequest("Attempted to modify a different resource");

            _context.Update(book);
            await _context.SaveChangesAsync();
            var updated = await _context.Books.FindAsync(book.Id);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> PostBook(Book book) {
            var author_exists = await _context.Authors.FindAsync(book.AuthorId);

            if(author_exists == null)
                return BadRequest($"Author with id {book.AuthorId} doesn't exist");

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(long id) {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
                return NotFound();
            
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
