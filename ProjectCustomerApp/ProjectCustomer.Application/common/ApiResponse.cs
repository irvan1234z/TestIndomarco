public class ApiResponse<T>
{
    public string Message { get; set; }
    public string TransactionId { get; set; } = Guid.NewGuid().ToString(); // auto-generate unique id
    public T Data { get; set; }

    public ApiResponse(T data, string message = "")
    {
        Data = data;
        Message = message;
    }
}
