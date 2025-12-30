using ExpertLearning.Domain.SharedContext.ValueObjects;

namespace ExpertLearning.Domain.LearningContext.ValueObjects;

public record FlashcardAnswer : ValueObject
{
    public string Content { get; }  = string.Empty;

    private FlashcardAnswer(string content)
    {
        Content = content;
    }
    
    private FlashcardAnswer() {}

    public static FlashcardAnswer Create(string content) => new FlashcardAnswer(content);
}