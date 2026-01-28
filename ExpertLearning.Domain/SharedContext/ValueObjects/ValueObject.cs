using ExpertLearning.Domain.SharedContext.Exceptions;
using Flunt.Notifications;
using Flunt.Validations;

namespace ExpertLearning.Domain.SharedContext.ValueObjects;

public abstract record ValueObject() : IValidatable
{
    private List<Notification> _notifications = [];
    public IReadOnlyCollection<Notification> Notifications => _notifications.AsReadOnly();
    public bool IsValid => Notifications.Count == 0;

    protected void AddNotification(Notification notification) => _notifications.Add(notification);

    protected void AddNotifications<T>(Contract<T> contract) where T : ValueObject 
        => _notifications.AddRange(contract.Notifications);

}