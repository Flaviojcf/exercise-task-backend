using Microsoft.EntityFrameworkCore;
using todo_backend.Context;
using todo_backend.Interfaces;
using todo_backend.Repository;

namespace todo_backend.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                      IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
                    ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IExerciseRepository, ExerciseRepository>();

            return services;
        }
    }
}
