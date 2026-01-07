using ExpertLearning.Domain.SharedContext.Errors;

namespace ExpertLearning.Application.SharedContext.Abstractions;

public class Result<T>
{
    public bool Success => _errors.Count == 0 && Data is not null;
    private readonly List<Error> _errors = [];
    public IReadOnlyCollection<Error> Errors => _errors.ToList();
    public T? Data { get; private set; }

    public Result() { }

    public void SetData(T data) => Data = data;
    
    public void AddError(Error error) => _errors.Add(error);
    public void AddErrors(IEnumerable<Error> errors) => _errors.AddRange(errors);
    
    public bool HasErrors() => _errors.Count != 0;
}