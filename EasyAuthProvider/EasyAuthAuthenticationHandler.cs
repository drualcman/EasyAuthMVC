namespace EasyAuthProvider;
internal class EasyAuthAuthenticationHandler(IOptionsMonitor<EasyAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
    : AuthenticationHandler<EasyAuthOptions>(options, logger, encoder, clock)
{
    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        AuthenticateResult result = AuthenticateResult.NoResult();

        if(Request.Headers.ContainsKey("X-MS-CLIENT-PRINCIPAL-ID"))
        {
            StringValues principalId = Request.Headers["X-MS-CLIENT-PRINCIPAL-ID"];
            IEnumerable<Claim> claims = [new Claim(ClaimTypes.NameIdentifier, principalId)];
            ClaimsIdentity identity = new ClaimsIdentity(claims, Scheme.Name, ClaimTypes.NameIdentifier, "");
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            AuthenticationTicket ticket = new AuthenticationTicket(principal, Scheme.Name);
            result = AuthenticateResult.Success(ticket);
        }

        return Task.FromResult(result);
    }
}
