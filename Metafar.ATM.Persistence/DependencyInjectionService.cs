using Metafar.ATM.Application.DataBase;
using Metafar.ATM.Persistence.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Metafar.ATM.Persistence
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataBaseService>(options => options.UseSqlServer(configuration.GetConnectionString("Metafar")));
            services.AddScoped<IDataBaseService, DataBaseService>();

            return services;
        }
    }
}
