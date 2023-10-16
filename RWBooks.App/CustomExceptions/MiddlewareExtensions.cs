namespace RWBooks.App.CustomExceptions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder
                    .UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
