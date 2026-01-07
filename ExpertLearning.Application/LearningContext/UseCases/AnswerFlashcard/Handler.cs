using ExpertLearning.Application.SharedContext.Abstractions;
using ExpertLearning.Application.SharedContext.Extensions.Flunt;
using ExpertLearning.Application.SharedContext.Repositories;
using ExpertLearning.Domain.LearningContext.Entities;
using ExpertLearning.Domain.SharedContext.Errors;

namespace ExpertLearning.Application.LearningContext.UseCases.AnswerFlashcard;

public class Handler(ISubjectRepository repository) : IHandler<Command, Answer>
{
    public Task<Answer> HandleAsync(Command request, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public async Task<Result<Answer>> HandleAsync(Command request)
    {
        var result = new Result<Answer>();

        try
        {

            if (!request.Validate())
            {
                result.AddErrors(request.GetNotificationsAsErrors());
                return result;
            }

            Flashcard? flashcard = await repository.GetFlashcardByIdAsync(request.FlashcardId);

            if (flashcard is null)
            {
                result.AddError(Errors.FlashcardNotFound);
                return result;
            }
            
            var answer = Answer.Create(flashcard.Id, request.AnswerLevel);
            flashcard.AddAnswer(answer);
            
            flashcard = await repository.UpdateFlashcardAsync(flashcard);

            if (flashcard is null)
            {
                result.AddError(Errors.FailAssignAnswerFlashcardError);
                return result;
            }
            
            result.SetData(answer);
            return result;

        }
        catch (Exception e)
        {
            result.AddError(Error.GenericError(e.Message));
            return await Task.FromResult(result);
        }
        
    }
}