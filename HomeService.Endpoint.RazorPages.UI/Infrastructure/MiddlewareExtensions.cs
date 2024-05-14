namespace HomeService.Endpoint.RazorPages.UI.Infrastructure;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder CustomExceptionHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}