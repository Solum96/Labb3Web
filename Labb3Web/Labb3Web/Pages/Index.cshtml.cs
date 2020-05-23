using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Labb3Web.Data;
using Labb3Web.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Labb3Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MainContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IList<Viewing> Viewings { get; set; }
        
        [TempData]
        public string userMessage { get; set; }

        public IndexModel(ILogger<IndexModel> logger, MainContext context)
        {
            _logger = logger;
            _context = context;

            _context.Database.EnsureCreated();
        }

        public void OnGet()
        {
            if(_context.Viewings.FirstOrDefault() == default)
            {
                var movie1 = new Viewing
                {
                    Id = "1",
                    Movie = "Spodermann 3: Just the Dance scene",
                    Time = "17:00",
                    TicketsLeft = 50
                };
                var movie2 = new Viewing
                {
                    Id = "2",
                    Movie = "Leif GW Persson: The Grymtening",
                    Time = "20:00",
                    TicketsLeft = 50
                };
                var movie3 = new Viewing
                {
                    Id = "3",
                    Movie = "Störta Staten, Alfons Åberg!",
                    Time = "23:00",
                    TicketsLeft = 50
                };
                _context.Viewings.AddRange(new[] { movie1, movie2, movie3 });
                _context.SaveChanges();
            }

            try
            {
                Viewings = _context.Viewings.ToList();
            }
            catch
            {
                Viewings = new List<Viewing>();
            }
        }     
        

        public async Task<IActionResult> OnPost(string movie, int amount)
        {
            var entity = await _context.Viewings.Where(o => o.Movie == movie).FirstOrDefaultAsync();

            if (entity == null)
            {
                return NotFound();
            }

            if(entity.TicketsLeft < amount)
            {
                userMessage = "Not enough tickets left. Please try again.";
                return RedirectToPage("./Index");
            }

            if (amount > 12)
            {
                userMessage = "Maximum amount is 12 tickets. Please try again.";
                return RedirectToPage("./Index");
            }

            entity.TicketsLeft -= amount;

            if (await TryUpdateModelAsync(entity, "viewing", (item) => (item.TicketsLeft)))
            {
                await _context.SaveChangesAsync();
                userMessage = $"Success! You have booked {amount} tickets.";
                return RedirectToPage("./Index");
            }

            
            return Page();
        }

    }
}
