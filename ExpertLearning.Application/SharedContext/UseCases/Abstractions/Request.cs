using ExpertLearning.Application.SharedContext.Abstractions;
using Flunt.Notifications;

namespace ExpertLearning.Application.SharedContext.UseCases.Abstractions;

public abstract class Request<T> : Notifiable<Notification>, IRequest<T>
{
    public abstract bool Validate();
    
    public string GetNotificationsMessage() => string.Join(Environment.NewLine, Notifications);
}