using System.Linq;
using API.DTOs;
using API.entities;
using API.Extensions;
using AutoMapper;

namespace API.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles( )
        {
            CreateMap<Appusers,MemberDTOs>()
            .ForMember(dest=>dest.PhotoUrl,opt=>opt.MapFrom
            (src=>src.photos.FirstOrDefault(x=>x.isMain).url))
            .ForMember(dest=>dest.Age,opt=>opt.MapFrom
            (src=>src.DateOfBirth.CalAge()));
            CreateMap<Photo,PhotoDto>();
        }
    }
}