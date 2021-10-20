using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinfinAnalog.Data;
using MinfinAnalog.Domain.Entities;

namespace MinfinAnalog.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyRatesController : ControllerBase
    {
        private readonly MinfinAnalogContext _context;

        public CurrencyRatesController(MinfinAnalogContext context)
        {
            _context = context;
        }

        // GET: api/CurrencyRate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurrencyRate>>> GetCurrencyRates()
        {
            return await _context.CurrencyRates.ToListAsync();
        }

        // GET: api/CurrencyRate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CurrencyRate>> GetCurrencyRate(int id)
        {
            var currencyRate = await _context.CurrencyRates.FindAsync(id);

            if (currencyRate == null)
            {
                return NotFound();
            }

            return currencyRate;
        }

        // PUT: api/CurrencyRate/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurrencyRate(int id, CurrencyRate currencyRate)
        {
            if (id != currencyRate.Id)
            {
                return BadRequest();
            }

            _context.Entry(currencyRate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrencyRateExists(id))
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

        // POST: api/CurrencyRate
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CurrencyRate>> PostCurrencyRate(CurrencyRate currencyRate)
        {
            _context.CurrencyRates.Add(currencyRate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurrencyRate", new { id = currencyRate.Id }, currencyRate);
        }

        // DELETE: api/CurrencyRate/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CurrencyRate>> DeleteCurrencyRate(int id)
        {
            var currencyRate = await _context.CurrencyRates.FindAsync(id);
            if (currencyRate == null)
            {
                return NotFound();
            }

            _context.CurrencyRates.Remove(currencyRate);
            await _context.SaveChangesAsync();

            return currencyRate;
        }

        private bool CurrencyRateExists(int id)
        {
            return _context.CurrencyRates.Any(e => e.Id == id);
        }
    }
}
