using Microsoft.EntityFrameworkCore;
using WatchRazorPage.Data;

namespace WatchRazorPage.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WatchRazorPageContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<WatchRazorPageContext>>()))
            {
                if (context == null || context.Watch == null)
                {
                    throw new ArgumentNullException("Null WatchRazorPageContext");
                }

                if (context.Watch.Any())
                {
                    return;   // DB has been seeded
                }

                context.Watch.AddRange(
                    new Watch
                    {
                       BrandName = "Rolex",
                       ModelName = "Submariner",
                       ModelReference = "16613",
                       ReleaseDate = DateTime.Parse("1989-05-01")
                    },

                    new Watch
                    {
                        BrandName = "Rolex",
                        ModelName = "Sea-Dweller",
                        ModelReference = "126600",
                        ReleaseDate = DateTime.Parse("2017-01-01")
                    },

                    new Watch
                    {
                        BrandName = "Rolex",
                        ModelName = "Explorer",
                        ModelReference = "214270",
                        ReleaseDate = DateTime.Parse("2011-08-01")
                    },

                    new Watch
                    {
                        BrandName = "Omega",
                        ModelName = "Seamaster 300",
                        ModelReference = "23322412101001",
                        ReleaseDate = DateTime.Parse("2015-03-01")
                    },
                    new Watch
                    {
                        BrandName = "Tag Heuer",
                        ModelName = "Monaco Calibre 12 Steve Mcqueen",
                        ModelReference = "CAW2111",
                        ReleaseDate = DateTime.Parse("2019-07-01")
                    },
                    new Watch
                    {
                        BrandName = "Panerai",
                        ModelName = "Luminor Marina",
                        ModelReference = "PAM111",
                        ReleaseDate = DateTime.Parse("2002-08-01")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
