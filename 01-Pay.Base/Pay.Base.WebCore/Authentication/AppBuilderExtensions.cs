using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;

namespace Pay.Base.WebCore.Authentication
{
    public static class AppBuilderExtensions
    {
        // 模拟授权实现
        public static IApplicationBuilder UseAuthorize(this IApplicationBuilder app)
        {
            return app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/Account/Index")
                {
                    await next();
                }
                if(context.Request.Path.Value.StartsWith("/ui"))
                {
                    await next();
                }
                else if(context.Request.Path == "/Account/Login")
                {
                    await next();
                }
                else if(context.Request.Path == "/favicon.ico")
                {
                    await next();
                }
                else
                {
                    if (context.User?.Identity?.IsAuthenticated ?? false)
                    {
                        await next();
                    }
                    else
                    {
                        //if(context.Request.Path == "/")
                        //{
                        //    await context.ChallengeAsync();
                        //    return;
                        //}
                        context.Response.Redirect("/Account/Index");
                    }
                }
            });
        }
    }
}
