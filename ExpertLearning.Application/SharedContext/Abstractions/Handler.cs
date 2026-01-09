using IuriDev26.Mediator.Abstractions;

namespace ExpertLearning.Application.SharedContext.Abstractions;

public abstract class Handler<TRequest, TResponse> : IHandler<TRequest, Result<TResponse>>
    where TRequest : IRequest<Result<TResponse>>
{
    public abstract Task<Result<TResponse>> HandleAsync(TRequest request,
        CancellationToken cancellationToken = new CancellationToken());
}