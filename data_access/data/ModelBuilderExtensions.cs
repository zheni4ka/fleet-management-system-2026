using business_logic.Entities;
using Microsoft.EntityFrameworkCore;
namespace data_access.data
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder builder)
        {
             builder.Entity<Location>().HasData(
     
             new Location { Id = 1, City = "Kyiv", Country = "Ukraine" },
             new Location { Id = 2, City = "Lviv", Country = "Ukraine" },
             new Location { Id = 3, City = "Odessa", Country = "Ukraine" },
             new Location { Id = 4, City = "Kharkiv", Country = "Ukraine" },
             new Location { Id = 5, City = "Dnipro", Country = "Ukraine" },
             new Location { Id = 6, City = "Zaporizhzhia", Country = "Ukraine" },
             new Location { Id = 7, City = "Ivano-Frankivsk", Country = "Ukraine" },
             new Location { Id = 8, City = "Ternopil", Country = "Ukraine" },
             new Location { Id = 9, City = "Chernivtsi", Country = "Ukraine" },
             new Location { Id = 10, City = "Vinnytsia", Country = "Ukraine" },
             new Location { Id = 11, City = "Rivne", Country = "Ukraine" },
             new Location { Id = 12, City = "Lutsk", Country = "Ukraine" },
             new Location { Id = 13, City = "Poltava", Country = "Ukraine" },
             new Location { Id = 14, City = "Chernihiv", Country = "Ukraine" },
             new Location { Id = 15, City = "Cherkasy", Country = "Ukraine" },
             new Location { Id = 16, City = "Khmelnytskyi", Country = "Ukraine" },
             new Location { Id = 17, City = "Zhytomyr", Country = "Ukraine" },
             new Location { Id = 18, City = "Uzhhorod", Country = "Ukraine" },
             new Location { Id = 19, City = "Mykolaiv", Country = "Ukraine" },
             new Location { Id = 20, City = "Kherson", Country = "Ukraine" },
             new Location { Id = 21, City = "Sumy", Country = "Ukraine" },
             new Location { Id = 22, City = "Kropyvnytskyi", Country = "Ukraine" },


             new Location { Id = 24, City = "Warsaw", Country = "Poland" },
             new Location { Id = 25, City = "Krakow", Country = "Poland" },
             new Location { Id = 26, City = "Wroclaw", Country = "Poland" },
             new Location { Id = 27, City = "Gdansk", Country = "Poland" },
             new Location { Id = 28, City = "Poznan", Country = "Poland" },
             new Location { Id = 29, City = "Lodz", Country = "Poland" },
             new Location { Id = 30, City = "Katowice", Country = "Poland" },
             new Location { Id = 31, City = "Lublin", Country = "Poland" },
             new Location { Id = 32, City = "Rzeszow", Country = "Poland" },
             new Location { Id = 33, City = "Szczecin", Country = "Poland" },
             new Location { Id = 34, City = "Bydgoszcz", Country = "Poland" },
             new Location { Id = 35, City = "Gdynia", Country = "Poland" },
             new Location { Id = 36, City = "Bialystok", Country = "Poland" },
             new Location { Id = 37, City = "Czestochowa", Country = "Poland" },
             new Location { Id = 38, City = "Radom", Country = "Poland" },
             new Location { Id = 39, City = "Torun", Country = "Poland" },
             new Location { Id = 40, City = "Kielce", Country = "Poland" },
             new Location { Id = 41, City = "Gliwice", Country = "Poland" }
 );
        }
    }
}
