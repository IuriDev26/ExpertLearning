
using Flunt.Validations;

namespace ExpertLearning.SharedKernel.Extensions;

public static class FluntExtensions
{
    extension<T>(Contract<T> contract)
    {
        public string GetNotificationAsString()
            => string.Join(
                Environment.NewLine,
                contract.Notifications.Select(notification => $"{notification.Key} - {notification.Message}")
            );

    }
}