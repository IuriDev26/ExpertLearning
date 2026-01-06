using ExpertLearning.Application.SharedContext.Abstractions;
using ExpertLearning.Application.SharedContext.UseCases.Abstractions;
using ExpertLearning.Domain.LearningContext.Entities;
using ExpertLearning.Domain.LearningContext.ValueObjects;

namespace ExpertLearning.Application.LearningContext.UseCases.CreateFlashcard;

public sealed class Command : Request<Flashcard>
{
    public Question Question { get; }
    public FlashcardAnswer Answer { get; }
    
    public int SubjectId { get; }

    public Command(Question question, FlashcardAnswer answer, int subjectId)
    {
        Question = question;
        Answer = answer;
        SubjectId = subjectId;
    }

    public override bool Validate() => true;
}