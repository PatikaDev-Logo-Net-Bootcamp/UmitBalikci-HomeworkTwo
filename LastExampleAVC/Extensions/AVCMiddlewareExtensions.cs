using LastExampleAVC.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace LastExampleAVC.Extensions
{
    public static class AVCMiddlewareExtensions
    {
        public static IApplicationBuilder UseAVCMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AVCMiddleware>();
        }
    }
}
