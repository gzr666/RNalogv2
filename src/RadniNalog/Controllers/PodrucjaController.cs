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
    [Route("api/Podrucja")]
    public class PodrucjaController:Controller
    {

        private readonly ApplicationDbContext _context;

        public PodrucjaController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/MjestoRada
        [HttpGet]
        public async Task<IActionResult> GetPodrucja()
        {


            //return Ok(await _context.Podrucja.Include(t => t.MjestaRada).ToListAsync());

            return Ok(await _context.Podrucja.ToListAsync());




        }


    }
}
