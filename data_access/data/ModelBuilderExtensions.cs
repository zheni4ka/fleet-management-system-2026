using Microsoft.EntityFrameworkCore;
namespace data_access.data
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder builder)
        {
            // initial seed is handled at runtime seeder (IdentitySeeder)
        }
    }
}
