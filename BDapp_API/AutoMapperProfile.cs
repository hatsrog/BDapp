using AutoMapper;
using BDapp_API.DbModels;
using BDapp_Core.Classes;

namespace BDapp_API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Price, StockPrice>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.StockPrice))
                .ForMember(dest => dest.DateValue, opt => opt.MapFrom(src => src.Date));

            CreateMap<StockPrice, Price>()
                .ForMember(dest => dest.StockPrice , opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.DateValue));

            CreateMap<Stock, StockInformation>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Prices, opt => opt.MapFrom(src => src.Prices));

            CreateMap<StockInformation, Stock>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name ))
                .ForMember(dest => dest.Prices, opt => opt.MapFrom(src => src.Prices ));
        }
    }
}
