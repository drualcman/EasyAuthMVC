namespace Microsoft.Extensions.DependencyInjection;
public static class EasyAuthAuthenticationExtensions
{
    public static AuthenticationBuilder AddEasyAuth(this AuthenticationBuilder builder, string authenticationScheme, Action<EasyAuthOptions> configureOptions)
    {
        builder.Services.AddAuthentication()
          .AddScheme<EasyAuthOptions, EasyAuthAuthenticationHandler>(authenticationScheme, configureOptions);
        return builder;
    }

    public static AuthenticationBuilder AddEasyAuth(this AuthenticationBuilder builder)
    {
        builder.Services.AddAuthentication()
          .AddScheme<EasyAuthOptions, EasyAuthAuthenticationHandler>("EasyAuth", c => { });
        return builder;
    }
}
