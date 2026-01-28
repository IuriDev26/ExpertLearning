using ExpertLearning.Domain.UserContext.Entities;
using ExpertLearning.Domain.UserContext.ValueObjects;

namespace ExpertLearning.Domain.Tests.UserContext;

public class UserTests
{
    [Fact]
    public void ShouldCreateUser()
    {
        const string name = "Iuri de Lima Vieira";
        const string passwordValue = "123";
        var email = Email.Create("iuri.livi13@gmail.com");
        var password = Password.Create(passwordValue);
        
        var user = User.Create(name, email, password);
        
        Assert.NotNull(user);
        Assert.Equal(name, user.Name);
        Assert.Equal(email, user.Email);
        Assert.True(user.Password.Match(passwordValue));
    }
}