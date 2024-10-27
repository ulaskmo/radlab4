using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using radlab4._0.Data;
using radlab4._0.Models;

namespace radlab4._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdController : ControllerBase
    {
        private readonly AdDbContext _context;

        public AdController(AdDbContext context)
        {
            _context = context;
        }

        // GET: api/Ad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ad>>> GetAds()
        {
            return await _context.Ads.ToListAsync();
        }

        // GET: api/Ad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ad>> GetAd(int id)
        {
            var ad = await _context.Ads.FindAsync(id);

            if (ad == null)
            {
                return NotFound();
            }

            return ad;
        }

        // POST: api/Ad
        [HttpPost]
        public async Task<ActionResult<Ad>> PostAd(Ad ad)
        {
            _context.Ads.Add(ad);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAd), new { id = ad.Id }, ad);
        }

        // PUT: api/Ad/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAd(int id, Ad ad)
        {
            if (id != ad.Id)
            {
                return BadRequest();
            }

            _context.Entry(ad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdExists(id))
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

        // DELETE: api/Ad/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAd(int id)
        {
            var ad = await _context.Ads.FindAsync(id);
            if (ad == null)
            {
                return NotFound();
            }

            _context.Ads.Remove(ad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdExists(int id)
        {
            return _context.Ads.Any(e => e.Id == id);
        }
    }
}
