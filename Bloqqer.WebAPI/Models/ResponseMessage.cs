namespace Bloqqer.WebAPI.Models;

public sealed class ResponseMessage<T>
{
    public bool Success { get; init; }

    public IEnumerable<string>? Errors { get; init; }

    public T? Data { get; init; }
}