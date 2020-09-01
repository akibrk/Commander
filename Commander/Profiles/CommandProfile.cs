using AutoMapper;
using Commander.DTOs;
using Commander.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Commander.Profiles
{
    public class CommandProfile :Profile
    {
        public CommandProfile()
        {
            CreateMap<Command, CommandReadDTO>();
            CreateMap<CommandWriteDTO, Command>();
        }

    }

    //public class AutoMappingProfile : Profile
    //{
    //    public AutoMappingProfile()
    //    {
    //        CreateMap<Command, CommandReadDTO>();
    //        //CreateMap<{ModelName}, {ViewModelName}> ().ForMember(dest=> dest.);
    //        //CreateMap<{BindingModel}, {Model}> ().ForMember(dest=> dest.);
    //    }
    //}
}
