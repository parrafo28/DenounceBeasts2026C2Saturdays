using AutoMapper;
using DenounceBeasts.API.Models.Dtos;
using DenounceBeasts.API.Models.Entities;
using DenounceBeasts.Domain.Entities;

namespace DenounceBeasts.API.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ComplaintType, ComplaintTypeDto>().ReverseMap();
            //CreateMap<ComplaintTypeDto, ComplaintType>();

            CreateMap<Status, StatusDto>().ReverseMap();

            CreateMap<Sector, SectorDto>()
                .ForMember(d => d.MunicipalityName, o => o.MapFrom(s => s.Municipality != null ? s.Municipality.Name : "Unknown"));

            //CreateMap<SectorDto, Sector>();

            //CreateMap<Sector, CreateSectorDto>().ReverseMap();
            CreateMap<CreateSectorDto, Sector>();//.ReverseMap();
            CreateMap<Sector, DetailSectorDto>(); //.ReverseMap();

            CreateMap<Municipality, MunicipalityDto>().ReverseMap();
            //CreateMap<Municipality, MunicipalityDto>().ReverseMap()
            //    .ForMember(d=> d.Sectors;
            CreateMap<CreateMunicipalityDto, Municipality>();//.ReverseMap();
            //CreateMap<Municipality, CreateMunicipalityDto>().ReverseMap();
            //CreateMap<Municipality, UpdateMunicipalityDto>().ReverseMap();
            //CreateMap<UpdateMunicipalityDto, Municipality>();//.ReverseMap(); 

        }
    }
}
