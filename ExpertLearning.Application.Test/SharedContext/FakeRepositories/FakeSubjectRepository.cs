using ExpertLearning.Application.SharedContext.Repositories;
using ExpertLearning.Domain.LearningContext.Entities;

namespace ExpertLearning.Application.Test.SharedContext.FakeRepositories;

public class FakeSubjectRepository : ISubjectRepository
{
    private List<Subject> MockedSubjects { get; } = [];
    private List<Flashcard> MockedFlashcards { get; } = [];
    private int _countId = 1;

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

    public Task<Flashcard?> GetFlashcardByIdAsync(int flashcardId)
    {
        throw new NotImplementedException();
    }

    public Task<Flashcard?> UpdateFlashcardAsync(Flashcard flashcard)
    {
        throw new NotImplementedException();
    }
}