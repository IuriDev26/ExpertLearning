using ExpertLearning.Domain.LearningContext.ValueObjects;
using ExpertLearning.Domain.SharedContext.Entities;

namespace ExpertLearning.Domain.LearningContext.Entities;

public class Flashcard : Entity
{
    public Question Question { get; } = null!;
    public FlashcardAnswer Answer { get; } = null!;

    private Flashcard(Question question, FlashcardAnswer answer)
    {
        Question = question;
        Answer = answer;
    }
    
    private Flashcard() {}
    
    private static Flashcard Create(Question question, FlashcardAnswer answer) => new Flashcard(question, answer);
}