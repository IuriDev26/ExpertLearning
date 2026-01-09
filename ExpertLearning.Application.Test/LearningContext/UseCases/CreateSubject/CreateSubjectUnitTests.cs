using ExpertLearning.Application.LearningContext.UseCases.CreateSubject;
using ExpertLearning.Application.SharedContext.Abstractions;
using ExpertLearning.Application.Test.SharedContext.FakeRepositories;
using ExpertLearning.Domain.LearningContext.Entities;

namespace ExpertLearning.Application.Test.LearningContext.UseCases.CreateSubject;

public class CreateSubjectUnitTests()
{
    
    [Fact]
    public async Task ShouldCreateSubject()
    {
        const string subjectName = "AnySubject";
        var command = new Command(name: subjectName);
        var repository = new FakeSubjectRepository();
        var unitOfWork = new FakeUnitOfWork();
        var handler = new Handler(repository, unitOfWork);

        Result<Subject> result = await handler.HandleAsync(command);
        Subject? response = result.Data;
        
        Assert.True(result.Success);
        Assert.NotNull(response);
        Assert.IsType<Subject>(response);
    }
}