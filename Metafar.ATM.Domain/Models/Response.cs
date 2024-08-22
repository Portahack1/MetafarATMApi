namespace Metafar.ATM.Domain.Models;

public sealed class Response<T>
{
    public bool Success { get; set; }
    public bool DataNotFound { get; set; }
    public List<string>? Messages { get; set; }
    public T? Data { get; set; }
}