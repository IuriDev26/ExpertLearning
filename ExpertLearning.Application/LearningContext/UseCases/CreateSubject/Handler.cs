using ExpertLearning.Application.SharedContext.Abstractions;
using ExpertLearning.Application.SharedContext.Repositories;
using ExpertLearning.Domain.LearningContext.Entities;

namespace ExpertLearning.Application.LearningContext.UseCases.CreateSubject;

public class Handler(ISubjectRepository subjectRepository) : IHandler<Command, Subject>
{
    
    public async Task<Result<Subject>> HandleAsync(Command request)
    {
        var result = new Result<Subject>();
        try
        {
            if (!request.Validate())
            {
                result.AddError(request.GetNotificationsMessage());
                return result;
            }
            
            var subject = Subject.Create(request.Name);
            subject = await subjectRepository.CreateAsync(subject);
            
            result.SetData(subject);
            return result;
            
        }
        catch (Exception e)
        {
            result.AddError(e.Message);
            return result;
        }
    }

    public Task<Subject> HandleAsync(Command request, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }
}