using WebApplication1.Data.Models;

namespace WebApplication1.Data
{
    public class AppDbInitializer
    {
        public static void seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "first book",
                        Description = "first description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        CoverUrl = "https",
                        DateAdded = DateTime.Now
                    }, new Book()
                    {
                        Title = "second book",
                        Description = "second description",
                        IsRead = false,
                        Genre = "Biography",
                        CoverUrl = "https",
                        DateAdded = DateTime.Now
                    });
                    context.SaveChanges();
                }
                
            }
        }
    }
}
