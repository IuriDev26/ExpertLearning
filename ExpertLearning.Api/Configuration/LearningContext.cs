using ExpertLearning.Application.SharedContext.Repositories;
using ExpertLearning.Infrastructure.Repositories;

namespace ExpertLearning.Api.Configuration;

public static class LearningContext
{
    public static IServiceCollection AddLearningContext(this IServiceCollection services)
    {
        services.AddScoped<ISubjectRepository, SubjectRepository>();
        return services;
    }
}