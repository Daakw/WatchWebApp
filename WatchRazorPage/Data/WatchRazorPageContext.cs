using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WatchRazorPage.Models;

namespace WatchRazorPage.Data
{
    public class WatchRazorPageContext : DbContext
    {
        public WatchRazorPageContext (DbContextOptions<WatchRazorPageContext> options)
            : base(options)
        {
        }

        public DbSet<WatchRazorPage.Models.Watch> Watch { get; set; } = default!;
    }
}
