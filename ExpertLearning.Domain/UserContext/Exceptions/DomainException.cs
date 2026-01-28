using ExpertLearning.Domain.SharedContext.Entities;
using ExpertLearning.Domain.SharedContext.Exceptions;
using ExpertLearning.Domain.SharedContext.ValueObjects;
using ExpertLearning.SharedKernel.Extensions;
using Flunt.Notifications;
using Flunt.Validations;

namespace ExpertLearning.Domain.UserContext.Exceptions;

public abstract class DomainException<TException, TValidatable>(string message) : DomainException(message)
    where TException : DomainException
    where TValidatable : IValidatable
{
    public static void ThrowIfInvalid<T>(Contract<T> contract)
    {
        if (!contract.IsValid)
            throw (TException)Activator.CreateInstance(typeof(TException), contract.GetNotificationAsString())!;
    }
    
}

public abstract class DomainException(string message) : Exception(message);