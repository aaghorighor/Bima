namespace Suftnet.Co.Bima.Api.Mappers
{
    using AutoMapper;
    using Suftnet.Co.Bima.Api.Models;
    using Suftnet.Co.Bima.DataAccess.Identity;
    using Suftnet.Co.Bima.DataAccess.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Customer();
            User();

        }

        private void Customer()
        {
            this.CreateMap<CreateCustomer, ApplicationUser>().ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email));
            this.CreateMap<UpdateCustomer, ApplicationUser>();
            this.CreateMap<CreateCustomer, Customer>();
        }

        private void User()
        {
            this.CreateMap<ApplicationUser, UserModel>();
        }
    }
}
