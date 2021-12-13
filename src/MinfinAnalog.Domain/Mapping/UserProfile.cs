using AutoMapper;
using MinfinAnalog.Domain.Entities;
using MinfinAnalog.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinfinAnalog.Domain.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Default mapping when property names are same
            CreateMap<User, UserDto>().ReverseMap();

            // Mapping when property names are different
            //CreateMap<User, UserDto>()
            //    .ForMember(dest => dest.Email,
            //        option => option.MapFrom(src => src.Email))
            //    .ForMember(dest => dest.FirstName,
            //        option => option.MapFrom(src => src.FirstName))
            //    .ForMember(dest => dest.LastName,
            //        option => option.MapFrom(src => src.LastName));

        }
    }
}
