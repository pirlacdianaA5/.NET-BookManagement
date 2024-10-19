namespace Application.Utils.Shared
{
    public record Error(string Code, string Message)
    {
        public static readonly Error None = new("No error", string.Empty);
        public static readonly Error General = new("General error", "An error occurred during the request");
        public static readonly Error NotFound = new("Not found", "The requested item was not found.");
        public static readonly Error Invalid = new("Invalid request", "The request was invalid.");

    }
}
