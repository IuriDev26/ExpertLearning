using ExpertLearning.Application.SharedContext.Abstractions;
using ExpertLearning.Application.SharedContext.Extensions.Flunt;
using ExpertLearning.Application.SharedContext.Repositories;
using ExpertLearning.Domain.LearningContext.Entities;
using ExpertLearning.Domain.SharedContext.Errors;
using IuriDev26.Mediator.Abstractions;

namespace ExpertLearning.Application.LearningContext.UseCases.CreateFlashcard;

public class Handler(ISubjectRepository repository) : Handler<Command, Flashcard>
{
    
    public override async Task<Result<Flashcard>> HandleAsync(Command request, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = new Result<Flashcard>();
        try
        {
            if (!request.Validate())
            {
                result.AddErrors(request.GetNotificationsAsErrors());
                return result;
            }

            Subject? subject = await repository.GetByIdAsync(request.SubjectId);
            
            if (subject is null)
            {
                result.AddError(Errors.SubjectNotFoundError);
                return result;
            }
            
            var flashcard = Flashcard.Create(subject.Id, request.Question, request.Answer);
            
            subject.AddFlashcard(flashcard);
            await repository.UpdateAsync(subject);
            
            result.SetData(flashcard);
            return result;

        }
        catch (Exception err)
        {
            result.AddError(Error.GenericError(err.Message));
            return result;
        }
    }
}