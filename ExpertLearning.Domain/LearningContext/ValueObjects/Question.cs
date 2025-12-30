using ExpertLearning.Domain.SharedContext.ValueObjects;

namespace ExpertLearning.Domain.LearningContext.ValueObjects;

public record Question : ValueObject
{
    public string Content { get; } = string.Empty;

    private Question(string content)
    {
        Content = content;
    }
    
    private Question() {}
    
    public static Question Create(string name) => new Question(name);
}