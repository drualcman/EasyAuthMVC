using Microsoft.AspNetCore.Authentication;

namespace EasyAuthProvider;

public class EasyAuthOptions : AuthenticationSchemeOptions
{
    public bool SaveToken { get; set; }
}
