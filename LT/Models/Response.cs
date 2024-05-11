namespace LT.Models
{
    public class Response<T>
    {
        public T Data { get; set; }
        public Error Error { get; set; }
    }

    public class Error
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}
