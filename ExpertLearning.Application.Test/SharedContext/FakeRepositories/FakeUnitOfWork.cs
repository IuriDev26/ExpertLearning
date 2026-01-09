using ExpertLearning.Application.SharedContext.UnitOfWork;

namespace ExpertLearning.Application.Test.SharedContext.FakeRepositories;

public class FakeUnitOfWork : IUnitOfWork
{
    public Task SaveAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    public Task RollbackAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}