namespace Application.Responses;

public class BaseResponse<T>
{
    public bool Success { get; set; } = true;
    public string? Message { get; set; }
    public T? Value { get; set; }
    public List<string> Errors { get; set; } = new List<string>();
}

