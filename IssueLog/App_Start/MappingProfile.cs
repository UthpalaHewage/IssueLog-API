using AutoMapper;
using IssueLog.Dtos;
using IssueLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueLog.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<User, UserDto>();
            Mapper.CreateMap<UserDto, User>().ForMember(m => m.Id, opt => opt.Ignore()); ;
        }
    }
}