namespace Suftnet.Co.Bima.DataAccess.Repository
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Suftnet.Co.Bima.Common;
    using Suftnet.Co.Bima.DataAccess.Identity;
    using Suftnet.Co.Bima.DataAccess.Interface;
    using Suftnet.Co.Bima.DataAccess.Actions;

    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class BimaContextInitializer : IBimaContextInitializer
    {
        private readonly v12Context _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;
        private readonly IRepository<Company> _company;
        private readonly IRepository<Buyer> _buyer;
        private readonly IRepository<Seller> _seller;
        private readonly IRepository<Driver> _logistic;

        public BimaContextInitializer(v12Context context, IRepository<Buyer> buyer, IRepository<Driver> logistic,
            UserManager<ApplicationUser> userManager, IRepository<Company> company, IRepository<Seller> seller,
            ILogger<BimaContextInitializer> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
            _company = company;
            _seller = seller;
            _buyer = buyer;
            _logistic = logistic;

        }
        public async Task SeedAsync(IConfiguration configuration)
        {
            await _context.Database.MigrateAsync().ConfigureAwait(false);
            CreateUsers();
            CreateCompany();
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

                    _context.SaveChanges();
                }

            }
            catch(Exception ex)
            {
                _logger.LogError(ex,"",null);
            };           

        }

        private void CreateCompany()
        {
            try
            {

                if (!_context.Company.Any())
                {
                    var buyerCompany = new Company { AreaId = new Guid(CompanyType.Buyer), Active = true, Description = "industry. Lorem Ipsum has been the industry's standard dummy", Name = "AB3Z", Email = "buyer@v12.com", PhoneNumber = "0123456789", CreatedBy = "Tester@Tester", CreatedAt = DateTime.Now };
                    buyerCompany.Id = new Guid();
                    _company.Add(buyerCompany);

                    var sellerCompany = new Company { AreaId = new Guid(CompanyType.Seller), Active = true, Description = "industry. Lorem Ipsum has been the industry's standard dummy", Name = "IRIT", Email = "seller@v12.com", PhoneNumber = "012345678SS9", CreatedBy = "Tester@Tester", CreatedAt = DateTime.Now };
                    sellerCompany.Id = new Guid();
                    _company.Add(sellerCompany);

                    var driverCompany = new Company { AreaId = new Guid(CompanyType.Logistic), Active = true, Description = "industry. Lorem Ipsum has been the industry's standard dummy", Name = "J52", Email = "logistic@v12.com", PhoneNumber = "012345678SSS9", CreatedBy = "Tester@Tester", CreatedAt = DateTime.Now };
                    driverCompany.Id = new Guid();
                    _company.Add(driverCompany);

                    var buyerUser = new ApplicationUser { UserType = UserType.BUYER, UserName = "buyer@v12.com", FirstName = "Buyer", LastName = "Buyer", Email = "buyer@v12.com", PhoneNumber = "0123456789", EmailConfirmed = true, CreatedAt = DateTime.Now, IsEnabled = true };
                    buyerUser.Id = Guid.NewGuid().ToString();
                    _userManager.CreateAsync(buyerUser, "P@ssw0rd!").Result.ToString();

                    var sellerUser = new ApplicationUser { UserType = UserType.SELLER, UserName = "seller@v12.com", FirstName = "Seller", LastName = "Seller", Email = "seller@v12.com", PhoneNumber = "012345678SS9", EmailConfirmed = true, CreatedAt = DateTime.Now, IsEnabled = true };
                    sellerUser.Id = Guid.NewGuid().ToString();
                    _userManager.CreateAsync(sellerUser, "P@ssw0rd!").Result.ToString();

                    var logisticUser = new ApplicationUser { UserType = UserType.DRIVER, UserName = "logistic@v12.com", FirstName = "Logistic", LastName = "Logistic", Email = "logistic@v12.com", PhoneNumber = "012345678SSS9", EmailConfirmed = true, CreatedAt = DateTime.Now, IsEnabled = true };
                    logisticUser.Id = Guid.NewGuid().ToString();
                    _userManager.CreateAsync(logisticUser, "P@ssw0rd!").Result.ToString();                 

                }

                if (!_context.Buyer.Any())
                {
                    var buyer = new Buyer { Description = "industry. Lorem Ipsum has been the industry's standard dummy", Active = true, ImageUrl = "", UserId = "621a117b-ef3d-4018-a371-b75f65333e5b", CompanyId = new Guid("327C28FB-01D0-4FBF-4125-08D8B7E74690"), FirstName = "Buyer", LastName = "Buyer", Email = "buyer@v12.com", PhoneNumber = "0123456789", CreatedAt = DateTime.Now, CreatedBy = "Tester@Tester" };
                    buyer.Id = Guid.NewGuid();
                   _buyer.Add(buyer);
                 
                }

                if (!_context.Seller.Any())
                {
                    var seller = new Seller { Description = "industry. Lorem Ipsum has been the industry's standard dummy", Active = true, ImageUrl = "", UserId = "2192115c-21df-4357-a92a-00b2d4c82b74", CompanyId = new Guid("158AB02F-99A4-4220-4126-08D8B7E74690"), FirstName = "Seller", LastName = "Seller", Email = "seller@v12.com", PhoneNumber = "012345678SS9", CreatedAt = DateTime.Now, CreatedBy = "Tester@Tester" };
                    seller.Id = Guid.NewGuid();
                   _seller.Add(seller);               
                }

                if (!_context.Driver.Any())
                {
                    var logistic = new Driver { Description = "industry. Lorem Ipsum has been the industry's standard dummy", Active = true, ImageUrl = "", UserId = "586dc4fc-5acc-464a-af53-35ce5deebb08", CompanyId = new Guid("E8C605BA-EC52-467F-4127-08D8B7E74690"), FirstName = "Logistic", LastName = "Logistic", Email = "logistic@v12.com", PhoneNumber = "012345678SSS9", CreatedAt = DateTime.Now, CreatedBy = "Tester@Tester" };
                    logistic.Id = Guid.NewGuid();
                   _logistic.Add(logistic);
                 
                }

                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "", null);
            };

        }

        #endregion
    }
}
