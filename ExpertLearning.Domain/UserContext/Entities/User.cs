using ExpertLearning.Domain.SharedContext.Entities;
using ExpertLearning.Domain.UserContext.Exceptions;
using ExpertLearning.Domain.UserContext.ValueObjects;
using Flunt.Validations;

namespace ExpertLearning.Domain.UserContext.Entities;

public sealed class User : Entity
{
    public string Name { get; } = string.Empty;
    public Email Email { get; } = null!;
    public Password Password { get; } = null!;

    public User() { }

    private User(string name, Email email, Password password)
    {
        Name = name;
        Email = email;
        Password = password;
    }

    public static User Create(string name, Email email, Password password)
    {
        UserInvalidException.ThrowIfInvalid(
            new Contract<User>()
                .Requires()
                .IsNotNullOrEmpty(name, nameof(name), "The name is required.")
        );

        return new User(name, email, password);
    }
}