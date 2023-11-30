using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Database
{
    public static class DatabaseConfig
    {
        public static void Setup(IServiceCollection services)
        {
            services.AddDbContext<CoreContext>(
                options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
        }
    }
}
