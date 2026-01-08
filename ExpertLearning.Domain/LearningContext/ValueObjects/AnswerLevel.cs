using ExpertLearning.Domain.SharedContext.ValueObjects;

namespace ExpertLearning.Domain.LearningContext.ValueObjects;

public record AnswerLevel : ValueObject
{
    public string Code { get; }

    private AnswerLevel(string code)
    {
        Code = code;
    }

    public static AnswerLevel Hard => new AnswerLevel("hard");
    public static AnswerLevel Medium => new AnswerLevel("medium");
    public static AnswerLevel Good => new AnswerLevel("good");
    public static AnswerLevel Excellent => new AnswerLevel("excellent");

}