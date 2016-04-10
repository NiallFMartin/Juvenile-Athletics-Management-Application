using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JuvenileSportsManagementApp.Models;
using JuvenileSportsManagementApp.Entities;

namespace JuvenileSportsManagementApp.App_Start
{
    public class AutoMapperConfig
    {

        // Registers all classes that are mapped using Automapper. View Models to Data Entities and vice versa
        public static void RegisterMappings()
        {
            RegisterViewModelsToData();
        }

        //register mappings
        public static void RegisterViewModelsToData()
        {
            AutoMapper.Mapper.CreateMap<AthleteDA, AthleteVM>();
            AutoMapper.Mapper.CreateMap<AthleteVM, AthleteDA>()
                .ForMember(dest => dest.AgeGroup, opt => opt.Ignore())
                .ForMember(dest => dest.Results, opt => opt.Ignore());

            AutoMapper.Mapper.CreateMap<EventDA, EventVM>();
            AutoMapper.Mapper.CreateMap<EventVM, EventDA>()
                .ForMember(dest => dest.Results, opt => opt.Ignore());

            AutoMapper.Mapper.CreateMap<GroupDA, GroupVM>();
            AutoMapper.Mapper.CreateMap<GroupVM, GroupDA>()
                .ForMember(dest => dest.Athletes, opt => opt.Ignore());

            AutoMapper.Mapper.CreateMap<ResultDA, ResultVM>()
                .ForMember(dest => dest.AthleteName, opt => opt.MapFrom(src => src.Athlete.AthleteName))
                .ForMember(dest => dest.EventName, opt => opt.MapFrom(src => src.Event.EventName));
            AutoMapper.Mapper.CreateMap<ResultVM, ResultDA>()
                .ForMember(dest => dest.Athlete, opt => opt.Ignore())
                .ForMember(dest => dest.Event, opt => opt.Ignore());




        }
    }
}