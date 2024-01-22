using AutoMapper;
using StudyProject.Data.Models;
using StudyProject.DTO.Country;
using StudyProject.DTOs.Country;
using StudyProject.DTOs.Hotel;

namespace StudyProject.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<Country, PostCountryDTO>().ReverseMap();
            CreateMap<Country, GetCountryDTO>().ReverseMap();
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, UpdateCountryDTO>().ReverseMap();

            CreateMap<Hotel, HotelDTO>().ReverseMap();
        }
    }
}
