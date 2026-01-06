using Flunt.Notifications;

namespace ExpertLearning.Application.SharedContext.Abstractions;

public interface IRequest<TResponse> : IuriDev26.Mediator.Abstractions.IRequest<TResponse>
{
    public bool Validate();
}