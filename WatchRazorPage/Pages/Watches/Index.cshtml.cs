using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WatchRazorPage.Data;
using WatchRazorPage.Models;

namespace WatchRazorPage.Pages.Watches
{
    public class IndexModel : PageModel
    {
        private readonly WatchRazorPage.Data.WatchRazorPageContext _context;

        public IndexModel(WatchRazorPage.Data.WatchRazorPageContext context)
        {
            _context = context;
        }

        public IList<Watch> Watch { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Brands { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? WatchBrand { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> modelQuery = from m in _context.Watch
                                            orderby m.ModelName
                                            select m.ModelName;

            var watches = from m in _context.Watch
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                watches = watches.Where(s => s.BrandName.Contains(SearchString));
            }
            Watch = await watches.ToListAsync();

            if (!string.IsNullOrEmpty(WatchBrand))
            {
                watches = watches.Where(x => x.ModelName == WatchBrand);
            }
            Brands = new SelectList(await modelQuery.Distinct().ToListAsync());
            Watch = await watches.ToListAsync();
           
        }
    }
}
