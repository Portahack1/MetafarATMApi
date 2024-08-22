using Metafar.ATM.Domain.Models;

namespace Metafar.ATM.Application.Features;

public static class ResponseService<T>
{
    public static Response<T> GetResponseOk(T? data = default)
    {
        return new Response<T>()
        {
            Success = true,
            Data = data
        };
    }

    public static Response<T> GetResponseSingleError(string? message, bool dataNotFound = false)
    {
        return new Response<T>()
        {
            Success = false,
            Messages = string.IsNullOrEmpty(message) ? null : [message],
            DataNotFound = dataNotFound
        };
    }

    public static Response<T> GetResponseMultipleErrors(List<string>? messages, T? data = default)
    {
        return new Response<T>()
        {
            Success = false,
            Messages = messages,
            Data = data
        };
    }
}
