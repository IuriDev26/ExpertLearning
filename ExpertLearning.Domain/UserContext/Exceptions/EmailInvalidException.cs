namespace ExpertLearning.Domain.UserContext.Exceptions;

public class EmailInvalidException(string message) : DomainException<EmailInvalidException, ValueObjects.Email>(message);
