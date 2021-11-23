using AutoMapper;
using Tekus.Core.Application.Dto.In;
using Tekus.Core.Application.DTO.Out;
using Tekus.Core.Domain.Entities;

namespace Application.Mapper
{
    public class GlobalMapperProfile : Profile
    {
        public GlobalMapperProfile() : base()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
            });

            configuration.CompileMappings();
            configuration.AssertConfigurationIsValid();

            #region Country
            CreateMap<CountryDto, Country>()
                .ForMember(dest => dest.Cioc, opt => opt.MapFrom(src => src.Identifier))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NameCountryDto))
                .ForMember(dest => dest.NumericCode, opt => opt.MapFrom(src => src.Code)).ReverseMap();
            #endregion

            #region Service
            CreateMap<ServiceDto, Service>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Identifier))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NameServiceDto))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.HourValueDto)).ReverseMap();
            #endregion

        }
    }
}