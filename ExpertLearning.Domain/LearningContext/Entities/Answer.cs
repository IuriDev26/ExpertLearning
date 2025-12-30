using ExpertLearning.Domain.LearningContext.Enums;
using ExpertLearning.Domain.SharedContext.Entities;

namespace ExpertLearning.Domain.LearningContext.Entities;

public class Answer : Entity
{
    public int FlashcardId { get; }
    public EAnswerLevel AnswerLevel { get;  }

    private Answer(int flashcardId, EAnswerLevel answerLevel)
    {
        FlashcardId = flashcardId;
        AnswerLevel = answerLevel;
    }
    
    private Answer() {}
    
    public static Answer Create(int flashcardId, EAnswerLevel answerLevel) => new Answer(flashcardId, answerLevel);
}