using System.Text.RegularExpressions;
using ExpertLearning.Domain.SharedContext.ValueObjects;
using ExpertLearning.Domain.UserContext.Exceptions;
using ExpertLearning.SharedKernel.Extensions;
using Flunt.Validations;

namespace ExpertLearning.Domain.UserContext.ValueObjects;

public sealed partial record Email : ValueObject
{

    private const string RegexPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    public string User { get; }
    public string Host { get; }

    [GeneratedRegex(RegexPattern, RegexOptions.IgnoreCase)]
    private static partial Regex RegexEmail();

    private Email(string user, string host)
    {
        User = user;
        Host = host;
    }

    public static Email Create(string email)
    {
        bool match = RegexEmail().IsMatch(email);
        
        Contract<Email> contract = new Contract<Email>()
            .Requires()
            .IsTrue(match, nameof(Email), $"The email don`t satisfies the pattern: {RegexPattern}");
        
        EmailInvalidException.ThrowIfInvalid(contract);
            
        int index = email.IndexOf('@');
        string user = email[..index];
        string host = email[(index + 1)..];
        
        return new Email(user, host);
    }
    
}