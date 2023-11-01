using AutoMapper;
using ProjectCylcone.API.Dtos;
using ProjectCylcone.API.Models.Entities;

namespace ProjectCylcone.API.Configs
{
    public class MapperConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappConfig = new MapperConfiguration(conf =>
            {
                conf.CreateMap<CarDTO, Car>().ReverseMap();
                conf.CreateMap<CarRegisterDTO, Car>().ReverseMap();
                conf.CreateMap<ClientDTO, Client>().ReverseMap();
                conf.CreateMap<ClientRegisterDTO, Client>().ReverseMap();
                conf.CreateMap<ColorDTO, Color>().ReverseMap();

            });
            return mappConfig;
        }
    }
}
