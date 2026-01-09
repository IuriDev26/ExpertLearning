using ExpertLearning.Application.SharedContext.Repositories;
using ExpertLearning.Domain.LearningContext.Entities;
using ExpertLearning.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ExpertLearning.Infrastructure.Repositories;

public class SubjectRepository(AppDbContext dbContext) : ISubjectRepository
{
    public async Task<Subject> CreateAsync(Subject subject)
    {
        await dbContext.Subjects.AddAsync(subject);
        return subject;
    }

    public Task<Subject?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Subject?> UpdateAsync(Subject subject)
    {
        throw new NotImplementedException();
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