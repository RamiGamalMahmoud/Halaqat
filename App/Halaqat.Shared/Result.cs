namespace Halaqat.Shared
{
    public class Result
    {
        public Result(bool isSuccess, string error = "")
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }
        public string Error { get; }

        public static Result Success => new Result(true, null);
    }

    public class Result<T> : Result where T : class
    {
        public Result(T value, bool isSuccess, string error) : base(isSuccess, error)
        {
            Value = value;
        }

        public T Value { get; }
    }
}
