using AutoMapper;
using MinfinAnalog.Data.Entities;
using MinfinAnalog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinfinAnalog.Domain.MappingConfigurations
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Default mapping when property names are same
            //CreateMap<User, UserDto>();

            // Mapping when property names are different
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Email,
                    option => option.MapFrom(src => src.Email))
                .ForMember(dest => dest.FirstName,
                    option => option.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName,
                    option => option.MapFrom(src => src.LastName));

        }
    }
}
