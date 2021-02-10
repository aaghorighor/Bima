namespace Suftnet.Co.Bima.Api.Mappers
{
    using AutoMapper;
    using Suftnet.Co.Bima.Api.Models;
    using Suftnet.Co.Bima.DataAccess.Identity;
    using Suftnet.Co.Bima.DataAccess.Actions;
    using Suftnet.Co.Bima.Api.Extensions;
    using System;
    using Suftnet.Co.Bima.Common;
    using System.Globalization;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<ApplicationUser, UserDto>()
                .ForMember(x => x.Description, map => map.Ignore())
                .ForMember(x => x.Password, map => map.Ignore())
                .ForMember(x=>x.Active, map=>map.MapFrom(j=>j.IsEnabled));
            this.CreateMap<CreateSeller, ApplicationUser>()
                .ForMember(x => x.IsEnabled, map => map.MapFrom(j => j.Active))
                .ForMember(x => x.UserName, map => map.MapFrom(j => j.Email))
                .ForMember(x => x.FullName, map => map.MapFrom(j => j.FirstName + " " + j.LastName));
            this.CreateMap<CreateBuyer, ApplicationUser>()
                .ForMember(x => x.IsEnabled, map => map.MapFrom(j => j.Active))
                .ForMember(x => x.UserName, map => map.MapFrom(j => j.Email))
                .ForMember(x => x.FullName, map => map.MapFrom(j => j.FirstName + " " + j.LastName));
            this.CreateMap<CreateDriver, ApplicationUser>()
                .ForMember(x => x.IsEnabled, map => map.MapFrom(j => j.Active))
                .ForMember(x => x.UserName, map => map.MapFrom(j => j.Email))
                .ForMember(x => x.FullName, map => map.MapFrom(j => j.FirstName + " " + j.LastName));

            this.CreateMap<CreateSeller, Seller>();
            this.CreateMap<CreateDriver, Driver>();
            this.CreateMap<CreateBuyer, Buyer>();

            this.CreateMap<CreateUser, ApplicationUser>()
                .ForMember(x => x.UserName, map => map.MapFrom(j => j.Email));
            this.CreateMap<UpdateUser, ApplicationUser>()
                .ForMember(x => x.UserName, map => map.MapFrom(j => j.Email));

            this.CreateMap<CreateCompany, Company>();
            this.CreateMap<UpdateCompany, Company>();

            this.CreateMap<CompanyDto, Company>();
            this.CreateMap<Company, CompanyDto>()
                .ForMember(x => x.Area, map => map.MapFrom(j => j.Area.Name))
                .ForMember(x=>x.AreaId, map=>map.Ignore());

            this.CreateMap<Seller, SellerDto>();
            this.CreateMap<Buyer, BuyerDto>();
            this.CreateMap<Driver, DriverDto>();

            this.CreateMap<Produce, ProduceDto>()
                .ForMember(x => x.PhoneNumber, map => map.MapFrom(j => j.Seller.PhoneNumber))
                .ForMember(x => x.FirstName, map => map.MapFrom(j => j.Seller.FirstName))
                .ForMember(x => x.LastName, map => map.MapFrom(j => j.Seller.LastName))
                .ForMember(x => x.Email, map => map.MapFrom(j => j.Seller.Email))
                .ForMember(x => x.Unit, map => map.MapFrom(j => j.Unit.Name))
                .ForMember(x=> x.AvailableDate, opts => opts.MapFrom(x=>x.AvailableDate.ToString("yyyy-MM-dd")));
            this.CreateMap<ProduceDto, Produce>();
            this.CreateMap<UpdateProduce, Produce>();

            this.CreateMap<Order, OrderDto>()
                .ForMember(x => x.Total, map => map.MapFrom(j => j.AmountPaid))
                .ForMember(x => x.Balance, map => map.MapFrom(j => j.AmountPaid));
            this.CreateMap<CreateOrder, Order>()
                .ForMember(x => x.Total, map => map.MapFrom(j => j.AmountPaid))
                .ForMember(x => x.Balance, map => map.MapFrom(j => j.AmountPaid));


            this.CreateMap<Order, BuyerOrder>()
                .ForMember(x => x.Status, map => map.MapFrom(j => j.OrderStatus.Name))
                .ForMember(x => x.StatusId, map => map.MapFrom(j => j.OrderStatus.Id))
                .ForMember(x => x.CollectionAddress, map => map.MapFrom(j => j.Produce.CollectionAddress()))
                .ForMember(x => x.DeliveryAddress, map => map.MapFrom(j => j.DeliveryAddress()))
                .ForMember(x => x.AvailableDate, map => map.MapFrom(j => j.Produce.AvailableDate.ToString("yyyy-MM-dd")))
                .ForMember(x => x.Quantity, map => map.MapFrom(j => j.Produce.Quantity))
                .ForMember(x => x.Unit, map => map.MapFrom(j => j.Produce.Unit.Name))
                .ForMember(x => x.PhoneNumber, map => map.MapFrom(j => j.Produce.Seller.PhoneNumber))
                .ForMember(x => x.Contact, map => map.MapFrom(j => j.Produce.Seller.FirstName + " " + j.Produce.Seller.LastName))
                .ForMember(x => x.ItemName, map => map.MapFrom(j => j.Produce.Name));

            this.CreateMap<Order, SellerOrder>()
                .ForMember(x => x.Status, map => map.MapFrom(j => j.OrderStatus.Name))
                .ForMember(x => x.StatusId, map => map.MapFrom(j => j.OrderStatus.Id))
                .ForMember(x => x.CollectionAddress, map => map.MapFrom(j => j.Produce.CollectionAddress()))
                .ForMember(x => x.DeliveryAddress, map => map.MapFrom(j => j.DeliveryAddress()))
                .ForMember(x => x.AvailableDate, map => map.MapFrom(j => j.Produce.AvailableDate.ToString("yyyy-MM-dd")))
                .ForMember(x => x.Quantity, map => map.MapFrom(j => j.Produce.Quantity))
                .ForMember(x => x.Unit, map => map.MapFrom(j => j.Produce.Unit.Name))
                .ForMember(x => x.PhoneNumber, map => map.MapFrom(j => j.Buyer.PhoneNumber))
                .ForMember(x => x.Contact, map => map.MapFrom(j => j.Buyer.FirstName + " " + j.Buyer.LastName))
                .ForMember(x => x.ItemName, map => map.MapFrom(j => j.Produce.Name));

            this.CreateMap<DeliveryDto, Delivery>();

            this.CreateMap<Order, DriverOrder>()
               .ForMember(x => x.Status, map => map.MapFrom(j => j.OrderStatus.Name))
               .ForMember(x => x.StatusId, map => map.MapFrom(j => j.OrderStatus.Id))
               .ForMember(x => x.CollectionAddress, map => map.MapFrom(j => j.Produce.CollectionAddress()))
               .ForMember(x => x.DeliveryAddress, map => map.MapFrom(j => j.DeliveryAddress()))
               .ForMember(x => x.AvailableDate, map => map.MapFrom(j => j.Produce.AvailableDate.ToString("yyyy-MM-dd")))
               .ForMember(x => x.Quantity, map => map.MapFrom(j => j.Produce.Quantity))
               .ForMember(x => x.Unit, map => map.MapFrom(j => j.Produce.Unit.Name))
               .ForMember(x => x.PhoneNumber, map => map.MapFrom(j => j.Produce.Seller.PhoneNumber))
               .ForMember(x => x.Contact, map => map.MapFrom(j => j.Produce.Seller.FirstName + " " + j.Produce.Seller.LastName))
               .ForMember(x => x.ItemName, map => map.MapFrom(j => j.Produce.Name));

            this.CreateMap<CreateQuestionDto, Question>();
            this.CreateMap<Question, QuestionDto>().ForMember(x => x.AnswerCount, map => map.MapFrom(j => j.Answers.Count))
                .ForMember(x => x.CreatedOn, map => map.MapFrom(j => j.CreatedDt.ToString("yyyy-MM-dd")));
            this.CreateMap<CreateAnswerDto, Answer>();
            this.CreateMap<Answer, AnswerDto>();
        }             
        
    }
}
