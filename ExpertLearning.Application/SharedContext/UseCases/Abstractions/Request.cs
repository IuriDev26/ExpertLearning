using ExpertLearning.Application.SharedContext.Abstractions;
using Flunt.Notifications;
using IuriDev26.Mediator.Abstractions;

namespace ExpertLearning.Application.SharedContext.UseCases.Abstractions;

public abstract class Request<T> : Notifiable<Notification>, IRequest<Result<T>>
{
    public abstract bool Validate();
    
    public string GetNotificationsMessage() => string.Join(Environment.NewLine, Notifications);
}