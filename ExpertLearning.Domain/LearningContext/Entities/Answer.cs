using ExpertLearning.Domain.LearningContext.ValueObjects;
using ExpertLearning.Domain.SharedContext.Entities;

namespace ExpertLearning.Domain.LearningContext.Entities;

public class Answer : Entity
{
    public int FlashcardId { get; }
    public AnswerLevel AnswerLevel { get; } = null!;

    private Answer(int flashcardId, AnswerLevel answerLevel)
    {
        FlashcardId = flashcardId;
        AnswerLevel = answerLevel;
    }
    
    private Answer() {}
    
    public static Answer Create(int flashcardId, AnswerLevel answerLevel) => new Answer(flashcardId, answerLevel);
}