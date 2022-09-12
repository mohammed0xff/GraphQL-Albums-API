using Microsoft.EntityFrameworkCore;
using AlbumsGraphQL.Models;


namespace Data.DataContext
{
    public static class AppDbInitializer
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var DbContextFactory = serviceScope.ServiceProvider.GetService<IDbContextFactory<AppDbContext>>();
                var context = DbContextFactory.CreateDbContextAsync().Result;

                context.Database.EnsureCreated();

                #region Seed Artists

                if (!context.Artists.Any())
                {
                    var artists = new List<Artist>();
                    artists.Add(new Artist()
                    {
                        Name = "The Doors",
                        Country = "USA",
                        Albums = new List<Album>()
                    {
                        new Album()
                        {
                            Title = "LA Woman",
                            Genre = "Rock",
                        },
                        new Album()
                        {
                            Title = "Strange Days",
                            Genre = "Rock",
                        }
                    }
                    });

                    artists.Add(new Artist()
                    {
                        Name = "Country Joe and the Fish",
                        Country = "USA",
                        Albums = new List<Album>()
                    {
                        new Album()
                        {
                            Title = "Here We Are Again",
                            Genre = "Blues"
                        },
                        new Album()
                        {
                            Title = "Together",
                            Genre = "Folk"
                        }
                    }
                    });

                    artists.Add(new Artist()
                    {
                        Name = "Janis Joplin",
                        Country = "USA",
                        Albums = new List<Album>()
                    {
                        new Album()
                        {
                            Title = "Pearl",
                            Genre = "Country"
                        }
                    }
                    });

                    artists.Add(new Artist()
                    {
                        Name = "Pink Floyd",
                        Country = "UK",
                        Albums = new List<Album>()
                    {
                        new Album()
                        {
                            Title = "The Dark Side of the Moon",
                            Genre = "Psychedelic Rock"
                        },
                        new Album()
                        {
                            Title = "The Division Bell",
                            Genre = "Psychedelic Rock"
                        },
                        new Album()
                        {
                            Title = "Animals",
                            Genre = "Psychedelic Rock"
                        },

                    }
                    });

                    context.Artists.AddRange(artists);
                    context.SaveChanges();
                }
                #endregion

            }
        }
    }
}

