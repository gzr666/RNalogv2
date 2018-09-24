using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RadniNalog.Data;
using RadniNalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadniNalog.Controllers
{

    [Produces("application/json")]
    [Route("api/TipPostrojenja")]
    public class TipPostrojenjaController:Controller
    {
        private readonly ApplicationDbContext _context;

        public TipPostrojenjaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MjestoRada
        [HttpGet]
        public async Task<IActionResult> GetMjestoRada()
        {
            //return Ok(await _context.TipoviPostrojenja.Include(t=>t.MjestaRada).ToListAsync());
            return Ok(await _context.TipoviPostrojenja.ToListAsync());
        }


        




    }
}
