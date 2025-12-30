namespace ExpertLearning.Application.Abstractions;

public class Result<T>
{
    public bool Success => _errors.Count == 0 && Data is not null;
    private readonly List<string> _errors = [];
    public IReadOnlyCollection<string> Errors => _errors.ToList();
    public T? Data { get; private set; }

    public Result() { }

    public void SetData(T data) => Data = data;
    
    public void AddError(string error) => _errors.Add(error);
    
    public string GetErrors() => HasErrors() ? string.Join(Environment.NewLine, _errors) : string.Empty;
    
    public bool HasErrors() => _errors.Count != 0;
}