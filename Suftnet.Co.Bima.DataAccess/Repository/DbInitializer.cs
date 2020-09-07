namespace Suftnet.Co.Bima.DataAccess.Repository
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Suftnet.Co.Bima.Common;
    using Suftnet.Co.Bima.DataAccess.Identity;
    using Suftnet.Co.Bima.DataAccess.Interface;
    using Suftnet.Co.Bima.DataAccess.Models;

    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class BimaContextInitializer : IBimaContextInitializer
    {
        private readonly BimaContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;

        public BimaContextInitializer(BimaContext context, UserManager<ApplicationUser> userManager, ILogger<BimaContextInitializer> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;

        }
        public async Task SeedAsync(IConfiguration configuration)
        {
            await _context.Database.MigrateAsync().ConfigureAwait(false);
            CreateUsers();
        }

        #region
        private void CreateUsers()
        {
            try {

                if (!_context.Users.Any())
                {
                    var adminUser = new ApplicationUser { UserType = UserType.BACKOFFICE, UserName = "admin@admin.com", FirstName = "Admin first", LastName = "Admin last", Email = "admin@admin.com", PhoneNumber = "0123456789", EmailConfirmed = true, CreatedAt = DateTime.Now, IsEnabled = true };
                    adminUser.Id = Guid.NewGuid().ToString();
                    _userManager.CreateAsync(adminUser, "P@ssw0rd!").Result.ToString();

                    var normalUser = new ApplicationUser { UserType = UserType.FRONTOFFICE, UserName = "user@user.com", FirstName = "First", LastName = "Last", Email = "user@user.com", PhoneNumber = "0123456789", EmailConfirmed = true, CreatedAt = DateTime.Now, IsEnabled = true };
                    normalUser.Id = Guid.NewGuid().ToString();
                    _userManager.CreateAsync(normalUser, "P@ssw0rd!").Result.ToString();

                    _context.SaveChanges();
                }

            }
            catch(Exception ex)
            {
                _logger.LogError(ex,"",null);
            };           

        }
        #endregion
    }
}
