using ExpertLearning.Domain.UserContext.ValueObjects;

namespace ExpertLearning.Domain.UserContext.Exceptions;

public class PasswordInvalidException(string message) : DomainException<PasswordInvalidException, Password>(message);