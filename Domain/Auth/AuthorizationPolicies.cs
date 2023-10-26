using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Auth;

public static class AuthorizationPolicies
{
    public static void AddPolicies(IServiceCollection services)
    {
        services.AddAuthorizationCore(options =>
        {
            options.AddPolicy("LoggedIn", a => a.RequireAuthenticatedUser().RequireAssertion(
                context =>
                {
                    return context.User.Identity.IsAuthenticated;
                }
            ));
        });
    }
}