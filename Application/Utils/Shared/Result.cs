namespace Application.Utils.Shared
{
    public class Result
    {
        public Result() { }

        public Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public bool IsSuccess { get; set; }
        public bool IsFailure => !IsSuccess;

        public static Result Success() => new(true);
        public static Result Failure() => new(false);
        public static Result<T> Success<T>(T value) => new Result<T>(value, isSuccess: true);
        public static Result<T> Failure<T>() => new Result<T>(default, isSuccess: false);

        public static Result Create(bool condition)
        {
            Result Success() => new(true);
            Result Failure() => new(false);
            return condition ? Success() : Failure();
        }

        public static Result<T> Create<T>(T? value)
        {
            Result<T> Success(T val) => new(val, true);
            Result<T> Failure() => new(default, false);
            return value is not null ? Success(value) : Failure();
        }
    }
}
