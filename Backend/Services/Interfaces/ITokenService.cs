using Drugsearch.Models;

namespace Drugsearch.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(ApplicationUser user);
    }
}