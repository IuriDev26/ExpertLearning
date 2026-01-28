using ExpertLearning.Domain.UserContext.Entities;

namespace ExpertLearning.Domain.UserContext.Exceptions;

public class UserInvalidException(string message) : DomainException<UserInvalidException, User>(message);