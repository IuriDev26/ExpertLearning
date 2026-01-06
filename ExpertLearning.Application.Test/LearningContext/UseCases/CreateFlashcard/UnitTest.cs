using ExpertLearning.Application.LearningContext.UseCases.CreateFlashcard;
using ExpertLearning.Application.SharedContext.Abstractions;
using ExpertLearning.Application.Test.SharedContext.FakeRepositories;
using ExpertLearning.Domain.LearningContext.Entities;
using ExpertLearning.Domain.LearningContext.ValueObjects;

namespace ExpertLearning.Application.Test.LearningContext.UseCases.CreateFlashcard;

public class UnitTest
{
    [Fact]
    public async Task ShouldCreateFlashcard()
    {
        var repository = new FakeSubjectRepository();
        var handler = new Handler(repository);

        var subject = Subject.Create("História");
        subject = await repository.CreateAsync(subject);
        
        var question = Question.Create("Quem descobriu o Brasil?");
        var answer = FlashcardAnswer.Create("Pedro Álvares Cabral");
        var command = new Command(question, answer, subject.Id);

        Result<Flashcard> result = await handler.HandleAsync(command);
        
        Assert.True(result.Success);
        Assert.NotNull(result.Data);
        Assert.NotNull(result.Data.Answer);
        Assert.NotNull(result.Data.Question);
    }
}