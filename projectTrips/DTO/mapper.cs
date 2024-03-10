using AutoMapper;
using DAL.Models;
using DTO.classes;
using Microsoft.Win32;
//using DTO.mapper;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Threading.Tasks.Dataflow;

namespace DTO.mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {

            CreateMap<DTO.classes.OrderPlace, DAL.Models.OrderPlace>()
                .ForMember(dest => dest.IdOrder, opt => opt.Ignore());
            CreateMap<DAL.Models.OrderPlace,DTO. classes.OrderPlace>()
                .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.IdUserNavigation.FirstName + " " + src.IdUserNavigation.LastName))
                .ForMember(dest => dest.Date,
                opt => opt.MapFrom(src => src.IdTripNavigation.Date))
                .ForMember(dest => dest.TargetTripe,
                opt => opt.MapFrom(src => src.IdTripNavigation.TargetTripe));


            CreateMap<DTO.classes.TheTrip, DAL.Models.TheTrip>();
              // .ForMember(dest => dest.IdTrip, opt => opt.Ignore());
            CreateMap<DAL.Models.TheTrip, DTO.classes.TheTrip>()
                .ForMember(dest => dest.NameType,
                opt => opt.MapFrom(src => src.IdTypeNavigation.NameType));
                //.ForMember(dest => dest.Medic,
                //opt => opt.MapFrom(src => src.OrderPlaces.Count(e => e.IdUserNavigation.FirstAidCertificate == true)));
            
            CreateMap<DAL.Models.TypesTrip, DTO.classes.TypesTrip>();
            CreateMap<DTO.classes.TypesTrip, DAL.Models.TypesTrip>()
              .ForMember(dest => dest.IdType, opt => opt.Ignore());

            CreateMap<DAL.Models.User, DTO.classes.User>();
            CreateMap<DTO.classes.User, DAL.Models.User>();
            // .ForMember(dest => dest.IdUser, opt => opt.Ignore());

        }
    }
}
