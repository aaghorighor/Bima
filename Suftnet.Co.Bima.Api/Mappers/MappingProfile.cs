namespace Suftnet.Co.Bima.Api.Mappers
{
    using AutoMapper;
    using Suftnet.Co.Bima.Api.Models;
    using Suftnet.Co.Bima.DataAccess.Identity;
    using Suftnet.Co.Bima.DataAccess.Actions;
  
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<ApplicationUser, UserDto>().ForMember(x => x.Description, map => map.Ignore()).ForMember(x => x.Password, map => map.Ignore());
            this.CreateMap<CreateSeller, Seller>();
            this.CreateMap<CreateDriver, Driver>();
            this.CreateMap<CreateBuyer, Buyer>();

            this.CreateMap<CreateUser, ApplicationUser>().ForMember(x => x.UserName, map => map.MapFrom(j => j.Email));
            this.CreateMap<UpdateUser, ApplicationUser>();
                     
            this.CreateMap<CreateCompany, Company>();
            this.CreateMap<UpdateCompany, Company>();

            this.CreateMap<CompanyDto, Company>();
            this.CreateMap<Company, CompanyDto>().ForMember(x => x.Area, map => map.MapFrom(j => j.Area.Name)).ForMember(x=>x.AreaId, map=>map.Ignore());

            this.CreateMap<Seller, SellerDto>().ForMember(x => x.Company, map => map.MapFrom(j => j.Company.Name));
            this.CreateMap<Buyer, BuyerDto>().ForMember(x => x.Company, map => map.MapFrom(j => j.Company.Name));
            this.CreateMap<Driver, DriverDto>().ForMember(x => x.Company, map => map.MapFrom(j => j.Company.Name));
           
        }        
        
    }
}
