using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moviepro.Models;
using System;
using System.Linq;

namespace MoviePro.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<ApplicationDbContext>>()))
            {

                if (!context.Studios.Any())
                {
                    context.Studios.AddRange(
                        new Studio
                        {
                            Name = "Miramax",
                            FoundedDate = DateTime.Parse("1989-2-12"),
                            Location = "Hollywood, CA",
                            Revenue = 10000000000
                        },
                    
                        new Studio
                        {
                            Name = "Universal",
                            FoundedDate = DateTime.Parse("1915-2-12"),
                            Location = "Wilmington, NC",
                            Revenue = 100000
                        }
                        );
                    context.SaveChanges();
                }


                // Look for any movies.
                if (context.Movies.Any())
                {
                    return; // DB has been seeded
                }

                var studioId = context.Studios.FirstOrDefault(s => s.Name == "Universal").Id;

                context.Movies.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Price = 7.99M,
                        StudioId = studioId
                    },

                    new Movie
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 8.99M,
                        StudioId = studioId
                    },

                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = 9.99M,
                        StudioId = studioId

                    },

                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M,
                        StudioId = studioId
                    }
               );
               
                context.SaveChanges();

            }
        }
    }
}
