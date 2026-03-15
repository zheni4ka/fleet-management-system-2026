using business_logic.Interfaces;
using data_access.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using data_access.data;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace data_access
{
    public static class ServiceExtensions
    {
        public static void AddDataAccessServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext(connectionString);
            services.AddRepositories();
        }
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TLMDbContext>(opts => opts.UseSqlServer(connectionString));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        public static void AddIdentity(this IServiceCollection services)
        {

        }
    }
}
