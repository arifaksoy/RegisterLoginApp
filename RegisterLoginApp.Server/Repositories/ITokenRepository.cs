using Microsoft.AspNetCore.Identity;

namespace RegisterLoginApp.Server.Repositories
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
