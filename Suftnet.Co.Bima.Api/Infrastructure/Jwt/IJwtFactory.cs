namespace Suftnet.Co.Bima.Api.Infrastructure
{
    using Suftnet.Co.Bima.DataAccess.Identity;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public interface IJwtFactory
    {
        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
        ClaimsIdentity GenerateClaimsIdentity(ApplicationUser applicationUser);
    }
}
