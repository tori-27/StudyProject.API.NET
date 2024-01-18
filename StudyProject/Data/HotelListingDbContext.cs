using Microsoft.EntityFrameworkCore;
using StudyProject.Data.Models;
using System.Security.Cryptography.X509Certificates;

namespace StudyProject.Data
{
    public class HotelListingDbContext : DbContext
    {
        public HotelListingDbContext(DbContextOptions options) : base(options) 
        {


        }
        public DbSet<Hotel> Hotels { get; set; }   
        public DbSet<Country> Contries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country 
                {
                    Id = 1,
                    Name = "Ukraine",
                    ShortName= "Uk"
                },
                new Country
                {
                    Id = 2,
                    Name = "Dominicana",
                    ShortName = "Dom"
                },
                new Country
                {
                    Id = 3,
                    Name = "Turkey",
                    ShortName = "Tur"
                }

            );

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Sandals Resort and Spa",
                    Address = "Negril",
                    CountryId = 1,
                    Rating = 4.5
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Comfort Hotel",
                    Address = "Tutkovskoho",
                    CountryId = 2,
                    Rating = 3.5
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Spa Resort",
                    Address = "Nezaleznosti",
                    CountryId = 3,
                    Rating = 4
                }
                );
        }
    }
}
