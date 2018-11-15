using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RadniNalog.Data;
using RadniNalog.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RadniNalog.Controllers
{
    [Route("api/TipDAS")]
    public class TipDASController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipDASController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<TipDas> Get()
        {
            return _context.TipoviDas;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTipDasa(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TipDas tipDasa = await _context.TipoviDas.SingleOrDefaultAsync(m => m.ID == id);

            if (tipDasa == null)
            {
                return NotFound();
            }

            return Ok(tipDasa);
        }

        // POST api/<controller>
        // POST: api/VrstaRada
        [HttpPost]
        public async Task<IActionResult> PostTipDas([FromBody] TipDas tipDas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TipoviDas.Add(tipDas);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TipDasExists(tipDas.ID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetTipDasa", new { id = tipDas.ID }, tipDas);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] TipDas tipDasa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipDasa.ID)
            {
                return BadRequest();
            }

            _context.Entry(tipDasa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipDasExists(id))
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

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TipDas tipDasa = await _context.TipoviDas.SingleOrDefaultAsync(m => m.ID == id);
            if (tipDasa == null)
            {
                return NotFound();
            }

            _context.TipoviDas.Remove(tipDasa);
            await _context.SaveChangesAsync();

            return Ok(tipDasa);

        }


        private bool TipDasExists(int id)
        {
            return _context.TipoviDas.Any(e => e.ID == id);
        }
    }
}
