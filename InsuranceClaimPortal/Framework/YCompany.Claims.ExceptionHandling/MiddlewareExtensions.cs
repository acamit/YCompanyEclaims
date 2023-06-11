using Microsoft.AspNetCore.Builder;

namespace YCompany.Claims.ExceptionHandling
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseYCompanyExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}