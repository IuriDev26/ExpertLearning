using ExpertLearning.Domain.SharedContext.Errors;
using ExpertLearning.Domain.SharedContext.Errors.Flashcard;

namespace ExpertLearning.Application.LearningContext.UseCases.AnswerFlashcard;

public static class Errors
{
    public static Error FlashcardNotFound => new FlashcardNotFoundError();
    public static Error FailAssignAnswerFlashcardError => new FailAssignAnswerFlashcardError();
}