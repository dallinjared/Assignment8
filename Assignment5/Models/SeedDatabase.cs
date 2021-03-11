using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment5.Models
{
    public class SeedDatabase
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            DaintreeDBContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<DaintreeDBContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Books.Any())
            {
                context.Books.AddRange(

                    new Book
                    {
                        Title = "Les Miserables",
                        Author= "Victor Hugo",
                        Publisher= "Signet",
                        ISBN= "978-0451419439",
                        Classification = "Fiction, Classic",
                        Price = 9.95,
                        Pages = 1488
                    },
                    new Book
                    {
                        Title = "Team of Rivals",
                        Author= "Doris Kearns Goodwin",
                        Publisher= "Simon & Schuster",
                        ISBN= "978-0743270755",
                        Classification = "Non-Fiction, Biography",
                        Price = 14.58,
                        Pages = 944
                    },
                    new Book
                    {
                        Title = "The Snowball",
                        Author = "Alice Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction, Biography",
                        Price = 21.54,
                        Pages = 832
                    },
                    new Book
                    {
                        Title = "American Ulysses",
                        Author = "Ronald C. White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Classification = "Non-Fiction, Biography",
                        Price = 11.61,
                        Pages = 864
                    },
                    new Book
                    {
                        Title = "Unbroken",
                        Author = "Laura Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Classification = "Non-Fiction, Historical",
                        Price = 13.33,
                        Pages = 528
                    },
                    new Book
                    {
                        Title = "The Great Train Robbery",
                        Author = "Michael Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Classification = "Fiction, Historical Fiction",
                        Price = 15.95,
                        Pages = 288
                    },
                    new Book
                    {
                        Title = "Deep Work",
                        Author = "Cal Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Classification = "Non-Fiction, Self-Help",
                        Price = 14.99,
                        Pages = 304
                    },
                    new Book
                    {
                        Title = "It's Your Ship",
                        Author = "Michael Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Classification = "Non-Fiction, Self-Help",
                        Price = 21.66,
                        Pages = 240
                    },
                    new Book
                    {
                        Title = "The Virgin Way",
                        Author = "Richard Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Classification = "Non-Fiction, Business",
                        Price = 29.16,
                        Pages = 400
                    },
                    new Book
                    {
                        Title = "Sycamore Row",
                        Author = "John Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Classification = "Fiction, Thrillers",
                        Price = 15.03,
                        Pages = 642
                    },
                    new Book
                    {
                        Title = "'Til The Boys Come Home",
                        Author = "Jerry Borrowman",
                        Publisher = "Covenant Communications",
                        ISBN = "978-1591567479",
                        Classification = "Historical Fiction, Religious",
                        Price = 23.03,
                        Pages = 423
                    },
                    new Book
                    {
                        Title = "The Hunger Games",
                        Author = "Suzanne Collins",
                        Publisher = "Scholastic Press",
                        ISBN = "978-0439023481",
                        Classification = "Science Fiction, Adventure",
                        Price = 9.96,
                        Pages = 374
                    },
                    new Book
                    {
                        Title = "Divergent",
                        Author = "Veronica Roth",
                        Publisher = "Katherine Tegen Books",
                        ISBN = "978-0062024039",
                        Classification = "Science Fiction, Adventure",
                        Price = 9.99,
                        Pages = 487
                    }
                );

                context.SaveChanges();
            }
        }

    }
}
