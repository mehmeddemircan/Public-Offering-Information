﻿using Public_Offering.Core.Entities.Concrete.Auth;

using Public_Offering.Entity.DTOs.UsersDtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.Business.Mappings
{
    public class UserProfile : Profile
    {

        public UserProfile()
        {
        

            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserUpdateDto>();

            CreateMap<UsersDto, User>();
            CreateMap<User, UsersDto>();

            CreateMap<UserDetailDto, User>();
            CreateMap<User, UserDetailDto>();
        }
    }
}
