using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IndexModel(ILogger<IndexModel> logger, MainContext context)
        {
            _logger = logger;
            _context = context;

            _context.Database.EnsureCreated();
        }

        public async void OnGet()
        {
            //await _context.Database.EnsureCreatedAsync();

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
                await _context.Viewings.AddRangeAsync(new[] { movie1, movie2, movie3 });
                await _context.SaveChangesAsync();
            }

            try
            {
                Viewings = await _context.Viewings.ToListAsync();
            }
            catch
            {
                Viewings = new List<Viewing>();
            }
        }     
        

    }
}
