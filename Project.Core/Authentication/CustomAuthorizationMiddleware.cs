using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http;

namespace Project.Core.Authentication
{
    public class CustomAuthorizationMiddleware : IAuthorizationMiddlewareResultHandler
    {
        private readonly AuthorizationMiddlewareResultHandler defaultHandler = new();
        public async Task HandleAsync(RequestDelegate next, HttpContext context, AuthorizationPolicy policy, PolicyAuthorizationResult authorizeResult)
        {
            if (authorizeResult.Succeeded)
            {
                //context.User.Claims.FirstOrDefault
            }
            else
            {
                Console.WriteLine("Thất bại");
            }

            await defaultHandler.HandleAsync(next, context, policy, authorizeResult);
        }
    }
}
