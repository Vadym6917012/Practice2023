using AutoMapper;
using AutomobileCatalog.Server.Core;
using AutomobileCatalog.Shared.Dtos;

namespace AutomobileCatalog.Server.Infrastructure
{
    public class AppAutoMapper : Profile
    {
        public AppAutoMapper() 
        {
            CreateMap<MakeReadDto, Make>();
            CreateMap<Make, MakeReadDto>();
        }
    }
}