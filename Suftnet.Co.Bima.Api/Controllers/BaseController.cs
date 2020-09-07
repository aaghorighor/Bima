namespace Suftnet.Co.Bima.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;  
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Suftnet.Co.Bima.Common;

    public abstract class BaseController : Controller
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public BaseController(IHttpContextAccessor httpContextAccessor)
        {
           this.httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<Claim> Claims
        {
            get
            {
                var claims = this.httpContextAccessor.HttpContext.User.Claims;
                if (claims == null || claims.Count() == 0)
                {
                    return Enumerable.Empty<Claim>();
                }

                return claims;
            }
        }

        public string Username
        {
            get
            {
                return this.Claims.Where(x => x.Type == JwtClaimIdentifiers.USER_NAME).Select(x => x.Value).SingleOrDefault();
            }
        }

        public string UserId
        {
            get
            {
                return this.Claims.Where(x => x.Type == JwtClaimIdentifiers.USER_ID).Select(x => x.Value).SingleOrDefault();
            }
        }

        public string FirstName
        {
            get
            {
                return this.Claims.Where(x => x.Type == JwtClaimIdentifiers.FIRST_NAME).Select(x => x.Value).SingleOrDefault();
            }
        }

        public string LastName
        {
            get
            {
                return this.Claims.Where(x => x.Type == JwtClaimIdentifiers.LAST_NAME).Select(x => x.Value).SingleOrDefault();
            }
        }

    }
}
