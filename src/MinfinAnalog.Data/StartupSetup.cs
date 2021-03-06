using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MinfinAnalog.Data;
public static class StartupSetup
{
    public static void AddDbContext(this IServiceCollection services, string connectionString) =>
        services.AddDbContext<MinfinAnalogContext>(options =>
            options.UseSqlServer(connectionString));
}
