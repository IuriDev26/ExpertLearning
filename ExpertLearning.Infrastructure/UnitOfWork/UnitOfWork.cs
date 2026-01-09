using ExpertLearning.Application.SharedContext.UnitOfWork;
using ExpertLearning.Infrastructure.DataAccess;

namespace ExpertLearning.Infrastructure.UnitOfWork;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    public async Task SaveAsync(CancellationToken cancellationToken) => await dbContext.SaveChangesAsync(cancellationToken);

    public Task RollbackAsync(CancellationToken cancellationToken) 
    {
        dbContext.ChangeTracker.Clear();
        return Task.CompletedTask;
    }
}