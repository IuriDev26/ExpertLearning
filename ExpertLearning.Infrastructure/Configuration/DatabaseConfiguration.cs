using ExpertLearning.Application.SharedContext.UnitOfWork;
using ExpertLearning.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExpertLearning.Infrastructure.Configuration;

public static class DatabaseConfiguration
{
    public static void AddDatabaseConfiguration(this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<AppDbContext>( options => options.UseNpgsql(connectionString) );
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
    }
}