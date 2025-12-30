using ExpertLearning.Domain.SharedContext.Entities;

namespace ExpertLearning.Domain.LearningContext.Entities;

public class Subject  : Entity
{
    public string Name { get; } = null!;
    private readonly List<Flashcard> _flashcards  = [];
    
    public IReadOnlyCollection<Flashcard> Flashcards => _flashcards.ToList();

    private Subject(string name)
    {
        Name = name;
    }
    
    private Subject() {}

    public static Subject Create(string name) => new Subject(name);
    
    public void AddFlashcard(Flashcard flashcard) => _flashcards.Add(flashcard);

}