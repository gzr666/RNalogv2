using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RadniNalog.Data;
using RadniNalog.Models;
using RadniNalog.ViewModels;

namespace RadniNalog.Controllers
{
    [Produces("application/json")]
    [Route("api/MjestoRada")]
    public class MjestoRadaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MjestoRadaController(ApplicationDbContext context)
        {
            _context = context;
        }


        

        // GET: api/MjestoRada
        [HttpGet]
        public IEnumerable<MjestoRadaViewModel> GetMjestoRada()
        {
            return _context.MjestoRada.Include(mjesto=>mjesto.Podrucje).
                Include(mjesto2=>mjesto2.TipPostrojenja).
                Include(tipDAS=>tipDAS.TipDas).
                Select(m=>ModelFactory.GetMjestoRadaVMDIRECT(m))
                .ToList();
        }

        // GET: api/MjestoRada/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMjestoRada([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MjestoRada mjestoRada = await _context.MjestoRada.SingleOrDefaultAsync(m => m.ID == id);

            if (mjestoRada == null)
            {
                return NotFound();
            }

            return Ok(mjestoRada);
        }

        // GET: api/MjestoRada/Kategorija5
        [HttpGet("kategorija/{id}")]
        public async Task<IActionResult> GetMjestoRadaPoKategoriji([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mjestaRada = await _context.MjestoRada.Where(mj => mj.PodrucjeID == id).ToListAsync();

            if (mjestaRada == null)
            {
                return NotFound();
            }

            return Ok(mjestaRada);
        }

        // PUT: api/MjestoRada/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMjestoRada([FromRoute] int id, [FromBody] MjestoRada mjestoRada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mjestoRada.ID)
            {
                return BadRequest();
            }

            _context.Entry(mjestoRada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MjestoRadaExists(id))
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

        // POST: api/MjestoRada
        [HttpPost]
        public async Task<IActionResult> PostMjestoRada([FromBody] MjestoRada mjestoRada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MjestoRada.Add(mjestoRada);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MjestoRadaExists(mjestoRada.ID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMjestoRada", new { id = mjestoRada.ID }, mjestoRada);
        }

        // DELETE: api/MjestoRada/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMjestoRada([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MjestoRada mjestoRada = await _context.MjestoRada.SingleOrDefaultAsync(m => m.ID == id);
            if (mjestoRada == null)
            {
                return NotFound();
            }

            _context.MjestoRada.Remove(mjestoRada);
            await _context.SaveChangesAsync();

            return Ok(mjestoRada);
        }

        private bool MjestoRadaExists(int id)
        {
            return _context.MjestoRada.Any(e => e.ID == id);
        }
    }
}