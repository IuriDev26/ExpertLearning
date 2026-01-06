using ExpertLearning.Application.SharedContext.Abstractions;
using ExpertLearning.Application.SharedContext.Repositories;
using ExpertLearning.Domain.LearningContext.Entities;

namespace ExpertLearning.Application.LearningContext.UseCases.CreateFlashcard;

public class Handler(ISubjectRepository repository) : IHandler<Command, Flashcard>
{
    public Task<Flashcard> HandleAsync(Command request, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public async Task<Result<Flashcard>> HandleAsync(Command request)
    {
        var result = new Result<Flashcard>();
        try
        {
            if (!request.Validate())
            {
                result.AddError(request.GetNotificationsMessage());
                return result;
            }

            var flashcard = Flashcard.Create(request.Question, request.Answer);

            Subject? subject = await repository.GetByIdAsync(request.SubjectId);

            if (subject is null)
            {
                result.AddError("Não foi possível criar o flashcard. O assunto informado não existe.");
                return result;
            }
            
            subject.AddFlashcard(flashcard);
            await repository.UpdateAsync(subject);
            
            result.SetData(flashcard);
            return result;

        }
        catch (Exception err)
        {
            result.AddError(err.Message);
            return result;
        }
    }
}