namespace Bloqqer.Application.Exceptions;

public sealed class UnauthorizedException : ApplicationException
{
    public UnauthorizedException(string message)
        : base(message)
    {
    }
}