using ExpertLearning.Domain.SharedContext.ValueObjects;

namespace ExpertLearning.Domain.UserContext.ValueObjects;

public sealed record Password(string Hash) : ValueObject
{
    public bool Match(string password) => true;
}