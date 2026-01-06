using ExpertLearning.Application.SharedContext.UseCases.Abstractions;

namespace ExpertLearning.Application.SharedContext.Abstractions;

public interface IHandler<in TRequest, TResponse> : IuriDev26.Mediator.Abstractions.IHandler<TRequest, TResponse>
    where TRequest : Request<TResponse>, IRequest<TResponse>
{
    public Task<Result<TResponse>> HandleAsync(TRequest request);
}