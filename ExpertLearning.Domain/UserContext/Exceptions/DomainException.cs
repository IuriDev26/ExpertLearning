using ExpertLearning.Domain.SharedContext.Exceptions;

namespace ExpertLearning.Domain.UserContext.Exceptions;

public abstract class DomainException<TException> : DomainException
    where TException : DomainException, new()
{
    public static void ThrowIfInvalid() =>
        throw new TException();
}

public abstract class DomainException : Exception;