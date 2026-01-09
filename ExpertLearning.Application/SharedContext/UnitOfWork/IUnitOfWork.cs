namespace ExpertLearning.Application.SharedContext.UnitOfWork;

public interface IUnitOfWork
{
    Task SaveAsync(CancellationToken cancellationToken);
    Task RollbackAsync(CancellationToken cancellationToken);
}