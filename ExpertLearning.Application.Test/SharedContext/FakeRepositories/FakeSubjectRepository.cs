using ExpertLearning.Application.SharedContext.Repositories;
using ExpertLearning.Domain.LearningContext.Entities;

namespace ExpertLearning.Application.Test.SharedContext.FakeRepositories;

public class FakeSubjectRepository : ISubjectRepository
{
    private List<Subject> MockedSubjects { get; } = [];
    private List<Flashcard> MockedFlashcards { get; } = [];
    private int _countId = 1;
    private int _countIdFlashcard = 1;

    public async Task<Subject> CreateAsync(Subject subject)
    {
        subject = Subject.Mock(_countId++, subject.Name);
        MockedSubjects.Add(subject);
        return await Task.FromResult(subject);
    }
    
    public async Task<Subject?> GetByIdAsync(int id)
        => await Task.FromResult(MockedSubjects.FirstOrDefault(x => x.Id == id));

    public async Task<Subject?> UpdateAsync(Subject subject)
    {
        Subject? oldSubject = MockedSubjects.FirstOrDefault( x => subject.Id == x.Id);

        if (oldSubject is null)
            return null;
        
        int subjectIndex = MockedSubjects.IndexOf(oldSubject);
        MockedSubjects[subjectIndex] = subject;
        return await Task.FromResult(subject);
    }

    public async Task<Flashcard?> GetFlashcardByIdAsync(int flashcardId)
        => await Task.FromResult(MockedFlashcards.FirstOrDefault(x => x.Id == flashcardId));

    public async Task<Flashcard?> UpdateFlashcardAsync(Flashcard flashcard)
    {
        Flashcard? oldFlashcard = MockedFlashcards.FirstOrDefault( x => flashcard.Id == x.Id);

        if (oldFlashcard is null)
            return null;
        
        int flashcardIndex = MockedFlashcards.IndexOf(oldFlashcard);
        MockedFlashcards[flashcardIndex] = flashcard;
        return await Task.FromResult(flashcard);
    }

    public Flashcard SeedFlashcard(Flashcard flashcard)
    {
        Flashcard newFlashcard = Flashcard.Mock(_countIdFlashcard++, flashcard.SubjectId, flashcard.Question,  flashcard.Answer);
        MockedFlashcards.Add(newFlashcard);
        return newFlashcard;
    }
}