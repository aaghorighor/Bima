namespace Suftnet.Co.Bima.DataAccess.Interface
{
    using Microsoft.Extensions.Configuration;
    using System.Threading.Tasks;

    public interface IBimaContextInitializer
    {
        Task SeedAsync(IConfiguration configuration);
    }
}
