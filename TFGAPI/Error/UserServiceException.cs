namespace TFGApi.Error;


public class UserServiceException : Exception
{
    public UserServiceException(string message, Exception innerException)
        : base(message, innerException) { }
}