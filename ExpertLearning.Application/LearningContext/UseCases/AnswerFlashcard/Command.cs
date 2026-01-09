using ExpertLearning.Application.SharedContext.UseCases.Abstractions;
using ExpertLearning.Domain.LearningContext.Entities;
using ExpertLearning.Domain.LearningContext.ValueObjects;
using Flunt.Validations;
using IuriDev26.Mediator.Abstractions;

namespace ExpertLearning.Application.LearningContext.UseCases.AnswerFlashcard;

public class Command(int flashcardId, AnswerLevel answerLevel) : Request<Answer>
{
    public int FlashcardId { get; } =  flashcardId;
    public AnswerLevel AnswerLevel { get; } = answerLevel;
    
    public override bool Validate()
    {
        var contract = new Contract<Answer>()
            .Requires()
            .IsGreaterThan(FlashcardId, 0, "FlashcardId", "O ID informado é inválido");
        
        AddNotifications(contract);
        
        return Notifications.Count == 0;
    }
}