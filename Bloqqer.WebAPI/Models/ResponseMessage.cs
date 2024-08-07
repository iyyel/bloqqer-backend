namespace Bloqqer.WebAPI.Models;

public sealed class ResponseMessage<T>
{
    public required bool Success { get; init; }

    public T? Data { get; init; }

    public string? Error { get; init; }
}