namespace FlashCards.WebAPI.Errors;

public enum ErrorCategory
{
    API = 100,
    Authorization = 200,
    Data = 300,
    Validation = 400,
}

public sealed class APIError(string message, ErrorCategory category)
{
    public readonly string Message = message;
    public readonly ErrorCategory Category = category;
}