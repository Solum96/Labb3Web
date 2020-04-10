﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Labb3Web.Data;
using Labb3Web.Data.Models;

namespace Labb3Web.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewingsController : ControllerBase
    {
        private readonly MainContext _context;

        public ViewingsController(MainContext context)
        {
            _context = context;
        }

        // GET: api/Viewings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Viewing>>> GetViewings()
        {
            return await _context.Viewings.ToListAsync();
        }

        // GET: api/Viewings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Viewing>> GetViewing(int id)
        {
            var viewing = await _context.Viewings.FindAsync(id);

            if (viewing == null)
            {
                return NotFound();
            }

            return viewing;
        }

        // PUT: api/Viewings/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViewing(int id, Viewing viewing)
        {
            if (id != viewing.Id)
            {
                return BadRequest();
            }

            _context.Entry(viewing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViewingExists(id))
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

        // POST: api/Viewings
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Viewing>> PostViewing(Viewing viewing)
        {
            _context.Viewings.Add(viewing);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetViewing", new { id = viewing.Id }, viewing);
        }

        // DELETE: api/Viewings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Viewing>> DeleteViewing(int id)
        {
            var viewing = await _context.Viewings.FindAsync(id);
            if (viewing == null)
            {
                return NotFound();
            }

            _context.Viewings.Remove(viewing);
            await _context.SaveChangesAsync();

            return viewing;
        }

        private bool ViewingExists(int id)
        {
            return _context.Viewings.Any(e => e.Id == id);
        }
    }
}
