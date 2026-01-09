using ExpertLearning.Application.SharedContext.Abstractions;
using ExpertLearning.Application.SharedContext.Extensions.Flunt;
using ExpertLearning.Application.SharedContext.Repositories;
using ExpertLearning.Application.SharedContext.UnitOfWork;
using ExpertLearning.Domain.LearningContext.Entities;
using ExpertLearning.Domain.SharedContext.Errors;
using IuriDev26.Mediator.Abstractions;

namespace ExpertLearning.Application.LearningContext.UseCases.CreateSubject;

public class Handler(ISubjectRepository subjectRepository, IUnitOfWork unitOfWork) : Handler<Command, Subject>
{
    
    public override async Task<Result<Subject>> HandleAsync(Command request, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = new Result<Subject>();
        try
        {
            if (!request.Validate())
            {
                result.AddErrors(request.GetNotificationsAsErrors());
                return result;
            }
            
            var subject = Subject.Create(request.Name);
            subject = await subjectRepository.CreateAsync(subject);
            await unitOfWork.SaveAsync(cancellationToken);
            
            result.SetData(subject);
            return result;
            
        }
        catch (Exception e)
        {
            result.AddError(Error.GenericError(e.Message));
            return result;
        }
    }
}