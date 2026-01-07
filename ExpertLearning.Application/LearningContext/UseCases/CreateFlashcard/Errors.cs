using ExpertLearning.Domain.SharedContext.Errors;
using ExpertLearning.Domain.SharedContext.Errors.Subject;

namespace ExpertLearning.Application.LearningContext.UseCases.CreateFlashcard;

public static class Errors
{
    public static Error SubjectNotFoundError => new SubjectNotFoundError();
}