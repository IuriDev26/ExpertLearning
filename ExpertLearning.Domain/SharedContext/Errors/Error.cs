namespace ExpertLearning.Domain.SharedContext.Errors;

public record Error(string Code, string Message)
{
    public static Error GenericError(string message) => new Error("Error.Generic", message);
}