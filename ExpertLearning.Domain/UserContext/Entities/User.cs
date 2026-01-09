using ExpertLearning.Domain.SharedContext.Entities;
using ExpertLearning.Domain.UserContext.ValueObjects;

namespace ExpertLearning.Domain.UserContext.Entities;

public sealed class User : Entity
{
    public string Name { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }
    
}