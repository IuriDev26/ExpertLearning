using ExpertLearning.Domain.LearningContext.Entities;

namespace ExpertLearning.Application.SharedContext.Repositories;

public interface ISubjectRepository
{
    public Task<Subject> CreateAsync(Subject subject);
    public Task<Subject?> GetByIdAsync(int id);
    public Task<Subject?> UpdateAsync(Subject subject);
    public Task<Flashcard?> GetFlashcardByIdAsync(int flashcardId);
    public Task<Flashcard?> UpdateFlashcardAsync(Flashcard flashcard);
}