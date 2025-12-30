using IuriDev26.Mediator.Abstractions;

namespace ExpertLearning.Application.Abstractions;

public interface IHandler<in TRequest, TResponse> : IuriDev26.Mediator.Abstractions.IHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public Task<Result<TResponse>> HandleAsync(TRequest request);
}