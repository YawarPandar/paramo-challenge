namespace Sat.Recruitment.Models.View
{
    public class BaseResult<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
