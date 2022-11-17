using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WatchRazorPage.Data;
using WatchRazorPage.Models;

namespace WatchRazorPage.Pages.Watches
{
    public class CreateModel : PageModel
    {
        private readonly WatchRazorPage.Data.WatchRazorPageContext _context;

        public CreateModel(WatchRazorPage.Data.WatchRazorPageContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Watch Watch { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Watch == null || Watch == null)
            {
                return Page();
            }

            _context.Watch.Add(Watch);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
