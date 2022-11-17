using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WatchRazorPage.Data;
using WatchRazorPage.Models;

namespace WatchRazorPage.Pages.Watches
{
    public class DeleteModel : PageModel
    {
        private readonly WatchRazorPage.Data.WatchRazorPageContext _context;

        public DeleteModel(WatchRazorPage.Data.WatchRazorPageContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Watch Watch { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Watch == null)
            {
                return NotFound();
            }

            var watch = await _context.Watch.FirstOrDefaultAsync(m => m.Id == id);

            if (watch == null)
            {
                return NotFound();
            }
            else 
            {
                Watch = watch;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Watch == null)
            {
                return NotFound();
            }
            var watch = await _context.Watch.FindAsync(id);

            if (watch != null)
            {
                Watch = watch;
                _context.Watch.Remove(Watch);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
