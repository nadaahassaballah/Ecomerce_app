namespace ecommerce.app.common
{
    public sealed record error(
        string codems,
        string message,
        errortype Type = errortype.failure)
    {
        public static error Failure(
            string code = "general.failure",
            string message = "Failure occurred")
            => new(code, message, errortype.failure);

        public static error Validation(
            string code = "general.validation",
            string message = "Validation occurred")
            => new(code, message, errortype.validation);

        public static error NotFound(
            string code = "general.notfound",
            string message = "Resource not found")
            => new(code, message, errortype.notfound);

        public static error Conflict(
            string code = "general.conflict",
            string message = "Conflict occurred")
            => new(code, message, errortype.conflict);

        public static error Unauthorized(
            string code = "general.unauthorized",
            string message = "Unauthorized access")
            => new(code, message, errortype.unauthorized);

        public static error Forbidden(
            string code = "general.forbidden",
            string message = "Access forbidden")
            => new(code, message, errortype.forbidden);

        public static error InvalidCredentials(
            string code = "general.invalidcredentials",
            string message = "Invalid credentials")
            => new(code, message, errortype.invalidcredtials);
    }
}