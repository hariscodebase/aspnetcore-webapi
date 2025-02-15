using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Data.Models;
using System.Linq;

namespace my_books.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if(!context.books.Any())
                {
                    context.books.AddRange(new Book()
                    {
                        Title = "Happiest Baby",
                        Description = "test"
                    },
                    new Book
                    {
                        Title = "Test",
                        Description = "test"
                    });
                }

                context.SaveChanges();
            }
        }
    }
}
