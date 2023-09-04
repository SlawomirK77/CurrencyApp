using AutoMapper;
using webapi.Entites;
using webapi.Models;

namespace webapi.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RateEntity, Rate>();
            CreateMap<CurrencyTableEntity, CurrencyTable>();
        }
    }
}