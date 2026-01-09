using System.Text.RegularExpressions;
using ExpertLearning.Domain.SharedContext.ValueObjects;

namespace ExpertLearning.Domain.UserContext.ValueObjects;

public sealed partial record Email : ValueObject
{

    private const string RegexPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    public string User { get; }
    public string Host { get; }

    [GeneratedRegex(RegexPattern, RegexOptions.IgnoreCase)]
    private static partial Regex RegexEmail();

    private Email(string email)
    {
        User = user;
        Host = host;
        
    }

    public static Email Create(string email)
    {
        
        
        var email = $"{user}@{host}";

        bool match = RegexEmail().IsMatch(email);

        return !match ? throw new Exception() : new Email(user, host);
    }
    
}