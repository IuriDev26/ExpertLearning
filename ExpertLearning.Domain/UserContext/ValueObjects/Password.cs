using ExpertLearning.Domain.SharedContext.ValueObjects;
using ExpertLearning.Domain.UserContext.Exceptions;
using Flunt.Validations;

namespace ExpertLearning.Domain.UserContext.ValueObjects;

public sealed record Password : ValueObject
{
    public string Hash { get; } =  string.Empty;

    private Password() { }
    
    private Password(string hash)
    {
        Hash = hash;
    }
    
    public bool Match(string password) => true;

    public static Password Create(string password)
    {
        PasswordInvalidException.ThrowIfInvalid(
            new Contract<Password>()
                .Requires()
                .IsNotNullOrEmpty(password, nameof(password), "The password is required.")
        );
        
        return new Password(password);
    }
}