using AutoMapper;
using Tekus.Core.Application.DTO.In;
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

            #region Provider
            CreateMap<ProviderDto, Provider>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Identifier))
                .ForMember(dest => dest.Nit, opt => opt.MapFrom(src => src.Nit))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NameProvider))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EmailProvider))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.AddressProvider))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.PhoneProvider)).ReverseMap();
            #endregion

            #region CustomAttribute

            CreateMap<AttributeDto, CustomAttribute>()              
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NameAttribute))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.TypeAttribute))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.ValueAttribute)).ReverseMap();

            #endregion

        }
    }
}