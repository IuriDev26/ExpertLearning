using ExpertLearning.Application.SharedContext.Abstractions;
using ExpertLearning.Application.SharedContext.Repositories;
using ExpertLearning.Domain.LearningContext.Entities;

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
                result.AddError(request.GetNotificationsMessage());
                return result;
            }

            Flashcard? flashcard = await repository.GetFlashcardByIdAsync(request.FlashcardId);

            if (flashcard is null)
            {
                result.AddError("Flashcard não encontrado. Não foi possível respondê-lo");
                return result;
            }
            
            var answer = Answer.Create(flashcard.Id, request.AnswerLevel);
            flashcard.AddAnswer(answer);
            
            flashcard = await repository.UpdateFlashcardAsync(flashcard);

            if (flashcard is null)
            {
                result.AddError("Falha ao atruibuir resposta ao flashcard");
                return result;
            }
            
            result.SetData(answer);
            return result;

        }
        catch (Exception e)
        {
            result.AddError(e.Message);
            return await Task.FromResult(result);
        }
        
    }
}