using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Labb3Web.Data;
using Labb3Web.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3Web.Pages
{
    public class AddMovieModel : PageModel
    {
        private readonly MainContext _context;

        public AddMovieModel(MainContext context)
        {
            _context = context;
        }

        // public IActionResult OnGet()
        // {
        //     return Page();
        // }

        //[BindProperty(SupportsGet = true)]
        //public Movie movie { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            //movie.Id = Guid.NewGuid();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            //await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        //public IList<Movie> Movies { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                //Movies = await _context.Movies.ToListAsync();
            }
            catch
            {
                //Movies = new List<Movie>();
            }

            return Page();
        }

        public IList<Ticket> Tickets { get; set; }

        public async Task<IActionResult> GetTicket()
        {
            try
            {
                var ticket = await _context.Tickets.Where(ticket => ticket.Booked == false).FirstOrDefaultAsync();
                Tickets.Add(ticket);
            }
            catch
            {

            }

            return Page();
        }
    }
}
