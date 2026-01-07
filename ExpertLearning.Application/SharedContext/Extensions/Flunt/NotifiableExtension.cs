using ExpertLearning.Domain.SharedContext.Errors;
using Flunt.Notifications;

namespace ExpertLearning.Application.SharedContext.Extensions.Flunt;

public static class NotifiableExtension
{
    public static List<Error> GetNotificationsAsErrors(this Notifiable<Notification> notifiable)
    {
        var errors = new List<Error>();
        notifiable.Notifications
            .ToList()
            .ForEach( notification => errors.Add(new Error(notification.Key, notification.Message)));
        
        return errors;
    }
}