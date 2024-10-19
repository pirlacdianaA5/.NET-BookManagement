namespace Application.Utils.Shared
{
    public class Result<T> : Result
    {
        private readonly T? _value;

        public Result() : base() { }

        protected internal Result(T? value, bool isSuccess) : base(isSuccess)
        {
            _value = value;
        }

        public T Value => IsSuccess ? _value! : throw new InvalidOperationException("No value present");

        public static implicit operator Result<T>(T? value) => Create(value);
    }
}
