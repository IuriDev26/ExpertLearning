using System.Reflection;
using IuriDev26.Mediator.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace ExpertLearning.Application.Configuration;

public static class Mediator
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediator(typeof(Mediator).Assembly);
        return services;
    }
}