using AutoMapper;
using MobileCompany.Models.Models;
using MobileCompany.ViewModels.Dto;

namespace MobileCompany;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Abonent, AbonentDto>()
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber.Number))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => $"{src.Address.Street}, {src.Address.City}"));
        // Добавьте другие маппинги здесь, если необходимо
    }
}