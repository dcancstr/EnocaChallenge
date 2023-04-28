using System;
using System.Reflection;
using AutoMapper;
using Enoca.Business.ViewModels.Carrier;
using Enoca.Business.ViewModels.CarrierConfiguration;
using Enoca.Business.ViewModels.CarrierReport;
using Enoca.Business.ViewModels.Order;
using Enoca.Entity.Concrete;

namespace Enoca.Business.AutoMappers
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
            CreateMap<Carrier, CreateCarrierVM>().ReverseMap();
            CreateMap<Carrier, UpdateCarrierVM>().ReverseMap();
            CreateMap<Carrier, GetCarrierVM>().ReverseMap();

            CreateMap<CarrierConfiguration, CreateCarrierConfigurationVM>().ReverseMap();
            CreateMap<CarrierConfiguration, UpdateCarrierConfigurationVM>().ReverseMap();
            CreateMap<CarrierConfiguration, GetCarrierConfigurationVM>().ReverseMap();

            CreateMap<CarrierReport, CreateCarrierReportVM>();
            CreateMap<CreateCarrierReportVM, CarrierReport>().ForMember(f => f.OrderDate, opt => opt.MapFrom(f => f.OrderDate));

            CreateMap<Order, CreateOrderVM>().ReverseMap();
            CreateMap<Order, UpdateOrderVM>().ReverseMap();
            CreateMap<Order, GetOrderVM>().ReverseMap();
        }
	}
}

