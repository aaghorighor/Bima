namespace Suftnet.Co.Bima.Api.Infrastructure
{  
    using Microsoft.Extensions.Options;
    using Suftnet.Co.Bima.Common;
    using Suftnet.Co.Bima.DataAccess.Identity;
    using System;  
    using System.IdentityModel.Tokens.Jwt;  
    using System.Security.Claims;
    using System.Security.Principal;
    using System.Threading.Tasks;

    public  class JwtFactory : IJwtFactory
    {        
        private readonly JwtIssuerOptions _jwtOptions;

        public JwtFactory(IOptions<JwtIssuerOptions> jwtOptions)
        {            
            _jwtOptions = jwtOptions.Value;
            ThrowIfInvalidOptions(_jwtOptions);
        }

        public async Task<string> GenerateEncodedToken(string userName, ClaimsIdentity claimsIdentity)
        {           
            var claims = new[]
            {
                 new Claim(JwtRegisteredClaimNames.Sub, userName),
                 new Claim(JwtRegisteredClaimNames.Jti, await _jwtOptions.JtiGenerator()),
                 new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),

                 claimsIdentity.FindFirst(JwtClaimIdentifiers.FIRST_NAME),
                 claimsIdentity.FindFirst(JwtClaimIdentifiers.LAST_NAME),
                 claimsIdentity.FindFirst(JwtClaimIdentifiers.USER_ID),
                 claimsIdentity.FindFirst(JwtClaimIdentifiers.USER_NAME),
                 claimsIdentity.FindFirst(JwtClaimIdentifiers.FULL_NAME)
             };
                       
            var jwt = new JwtSecurityToken(
                _jwtOptions.Issuer,
                _jwtOptions.Audience,
                claims,
                _jwtOptions.NotBefore,
                _jwtOptions.Expiration,
                _jwtOptions.SigningCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwt); 
        }

        public ClaimsIdentity GenerateClaimsIdentity(ApplicationUser user)
        {
            return new ClaimsIdentity(new GenericIdentity(user.UserName, "Token"), new[]
            {
                new Claim(JwtClaimIdentifiers.FIRST_NAME, user.FirstName),
                new Claim(JwtClaimIdentifiers.LAST_NAME, user.LastName),
                new Claim(JwtClaimIdentifiers.USER_ID, user.Id),
                new Claim(JwtClaimIdentifiers.USER_NAME, user.UserName),
                new Claim(JwtClaimIdentifiers.FULL_NAME, user.FullName)

            });
        }
               
        private static long ToUnixEpochDate(DateTime date)
          => (long)Math.Round((date.ToUniversalTime() -
                               new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
                              .TotalSeconds);

        private static void ThrowIfInvalidOptions(JwtIssuerOptions options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero)
            {
                throw new ArgumentException("Must be a non-zero TimeSpan.", nameof(JwtIssuerOptions.ValidFor));
            }

            if (options.SigningCredentials == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.SigningCredentials));
            }

            if (options.JtiGenerator == null)
            {
                throw new ArgumentNullException(nameof(JwtIssuerOptions.JtiGenerator));
            }
        }
    }
}
