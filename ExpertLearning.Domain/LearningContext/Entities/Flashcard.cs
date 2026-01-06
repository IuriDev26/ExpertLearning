using ExpertLearning.Domain.LearningContext.ValueObjects;
using ExpertLearning.Domain.SharedContext.Entities;

namespace ExpertLearning.Domain.LearningContext.Entities;

public class Flashcard : Entity
{
    public Question Question { get; } = null!;
    public FlashcardAnswer Answer { get; } = null!;
    private List<Answer> _answerHistory = [];
    public IReadOnlyCollection<Answer> AnswerHistory => _answerHistory.AsReadOnly();

    private Flashcard(Question question, FlashcardAnswer answer)
    {
        Question = question;
        Answer = answer;
    }
    
    private Flashcard(int id, Question question, FlashcardAnswer answer)
    {
        Id = id;
        Question = question;
        Answer = answer;
    }
    
    private Flashcard() {}
    
    public static Flashcard Create(Question question, FlashcardAnswer answer) => new Flashcard(question, answer);
    public static Flashcard Mock(int id, Question question, FlashcardAnswer answer) => new Flashcard(id, question, answer);
    

    public void AddAnswer(Answer answer) => _answerHistory.Add(answer);
}