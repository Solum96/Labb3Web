using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Labb3Web.Data;
using Labb3Web.Data.Models;

namespace Labb3Web.Pages
{
    public class AddViewingModel : PageModel
    {
        private readonly Labb3Web.Data.MainContext _context;

        public AddViewingModel(Labb3Web.Data.MainContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Viewing Viewing { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Viewings.Add(Viewing);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
