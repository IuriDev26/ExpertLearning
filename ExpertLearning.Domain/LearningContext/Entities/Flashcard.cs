using ExpertLearning.Domain.LearningContext.ValueObjects;
using ExpertLearning.Domain.SharedContext.Entities;

namespace ExpertLearning.Domain.LearningContext.Entities;

public class Flashcard : Entity
{
    public int SubjectId { get; }
    public Question Question { get; } = null!;
    public FlashcardAnswer Answer { get; } = null!;
    private readonly List<Answer> _answerHistory = [];
    public IReadOnlyCollection<Answer> AnswerHistory => _answerHistory.AsReadOnly();

    private Flashcard(int subjectId, Question question, FlashcardAnswer answer)
    {
        Question = question;
        Answer = answer;
        SubjectId = subjectId;
    }
    
    private Flashcard(int id, int subjectId, Question question, FlashcardAnswer answer)
    {
        Id = id;
        Question = question;
        Answer = answer;
        SubjectId = subjectId;
    }
    
    private Flashcard() {}
    
    public static Flashcard Create(int subjectId, Question question, FlashcardAnswer answer) => new Flashcard(subjectId, question, answer);
    public static Flashcard Mock(int id, int subjectId, Question question, FlashcardAnswer answer) => new Flashcard(id, subjectId, question, answer);
    

    public void AddAnswer(Answer answer) => _answerHistory.Add(answer);
}