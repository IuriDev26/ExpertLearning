namespace ExpertLearning.Domain.SharedContext.Errors.Subject;

public record SubjectNotFoundError() : Error("Subject.NotFound", "Assunto não encontrado");