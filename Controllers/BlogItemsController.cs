using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogSite_API.Models;

namespace BlogSite_API.Controllers
{
    [Route("api/blog")]
    [ApiController]
    public class BlogItemsController : ControllerBase
    {
        private readonly BlogContext _context;

        public BlogItemsController(BlogContext context)
        {
            _context = context;
        }

        // GET: api/BlogItems
        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<BlogItem>>> GetBlogItems()
        {
            return await _context.BlogItems.ToListAsync();
        }

        // GET: api/BlogItems/5
        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult<BlogItem>> GetBlogItem(int id)
        {
            var blogItem = await _context.BlogItems.FindAsync(id);

            if (blogItem == null)
            {
                return NotFound();
            }

            return blogItem;
        }

        // GET: api/BlogItems/username
        [HttpGet("get-by-user/{username}")]
        public async Task<ActionResult<IEnumerable<BlogItem>>> GetBlogItemsByUser(string username)
        {
            var blogItem = await _context.BlogItems.Where(u => u.Author == username).ToListAsync();

            if (blogItem == null)
            {
                return NotFound();
            }

            return blogItem;
        }

        // PUT: api/BlogItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("update/{id}")]
        public async Task<IActionResult> PutBlogItem(int id, BlogItem blogItem)
        {
            if (id != blogItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(blogItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogItemExists(id))
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

        // POST: api/BlogItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("create")]
        public async Task<ActionResult<BlogItem>> PostBlogItem(BlogItem blogItem)
        {
            _context.BlogItems.Add(blogItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostBlogItem), new { id = blogItem.Id }, blogItem);
        }

        // DELETE: api/BlogItems/5
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteBlogItem(int id)
        {
            var blogItem = await _context.BlogItems.FindAsync(id);
            if (blogItem == null)
            {
                return NotFound();
            }

            _context.BlogItems.Remove(blogItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BlogItemExists(int id)
        {
            return _context.BlogItems.Any(e => e.Id == id);
        }
    }
}
