using AutoMapper;
using AutomobileCatalog.Server.Core;
using AutomobileCatalog.Shared.Dtos;

namespace AutomobileCatalog.Server.Infrastructure
{
    public class AppAutoMapper : Profile
    {
        public AppAutoMapper() 
        {
            CreateMap<MakeCreateDto, Make>();
            CreateMap<Make, MakeReadDto>();

            CreateMap<ModelCreateDto, Model>();
                //.ForMember(dest => dest.Make, o => o.MapFrom(src => src.Make))
                //.ForMember(dest => dest.VehicleColor, o => o.MapFrom(src => src.VehicleColor)).ReverseMap();
            CreateMap<Model, ModelReadDto>();

            CreateMap<PriceCreateDto, Price>();
            CreateMap<Price, PriceReadDto>();

            CreateMap<VehicleColorCreateDto, VehicleColor>();
            CreateMap<VehicleColor, VehicleColorReadDto>();

            CreateMap<VehicleCreateDto, Vehicle>();
            CreateMap<Vehicle, VehicleReadDto>();
        }
    }
}