using ExpertLearning.Application.LearningContext.UseCases.AnswerFlashcard;
using ExpertLearning.Application.SharedContext.Abstractions;
using ExpertLearning.Application.Test.SharedContext.FakeRepositories;
using ExpertLearning.Domain.LearningContext.Entities;
using ExpertLearning.Domain.LearningContext.Enums;
using ExpertLearning.Domain.LearningContext.ValueObjects;

namespace ExpertLearning.Application.Test.LearningContext.UseCases.AnswerFlashcard;

public class UnitTests
{
    [Fact]
    public async Task ShouldAnswerFlashcard()
    {
        var repository = new FakeSubjectRepository();
        var handler = new Handler(repository);

        var question = Question.Create("Quem inventou o avião?");
        var answer = FlashcardAnswer.Create("Os Irmãos Wright");
        var flashcard = Flashcard.Create(question, answer);
        
        flashcard = repository.SeedFlashcard(flashcard);
        var command = new Command(flashcard.Id, EAnswerLevel.Excellent);
        
        Result<Answer> result = await handler.HandleAsync(command);
        
        Assert.True(result.Success);
        Assert.NotNull(result.Data);
        Assert.Equal(EAnswerLevel.Excellent, result.Data.AnswerLevel);
    }
    
    [Fact]
    public async Task ShouldReturnErrorWhenFlashcardNotFound()
    {
        var repository = new FakeSubjectRepository();
        var handler = new Handler(repository);
        
        var command = new Command(999, EAnswerLevel.Excellent);
        
        Result<Answer> result = await handler.HandleAsync(command);
        
        Assert.False(result.Success);
        Assert.Null(result.Data);
        Assert.Contains(Errors.FlashcardNotFound, result.Errors);
    }
    
}