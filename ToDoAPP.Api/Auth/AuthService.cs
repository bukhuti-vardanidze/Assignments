namespace ToDoApp.Api.Auth
{
    public interface IAuthService
{
    string Login(string email, string password);
}

public class AuthService : IAuthService
{
    private int _counter = 0;
    public string Login(string email, string password)
    {
        // Check user credentials in SQL Server
        return _counter++.ToString();
    }
}


public class FakeAuthService : IAuthService
{
    public string Login(string email, string password)
    {
        return "fake token";
    }
}
}
