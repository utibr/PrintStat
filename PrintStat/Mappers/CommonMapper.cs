using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using PrintStat.Models.ViewModels;

namespace PrintStat.Mappers
{
    public class CommonMapper: IMapper
    {
        static CommonMapper()
        {
            Mapper.CreateMap<PaperTypeView, PaperType>()
               .ForMember(dest => dest.Height_cm, opt => opt.MapFrom(src => src.Height_cm))
               .ForMember(dest => dest.Width_cm, opt => opt.MapFrom(src => src.Width_cm)); 
            Mapper.CreateMap<PaperType, PaperTypeView>()
               .ForMember(dest => dest.Height_cm, opt => opt.MapFrom(src => src.Height_cm))
               .ForMember(dest => dest.Width_cm, opt => opt.MapFrom(src => src.Width_cm));

            Mapper.CreateMap<DeviceType, DeviceTypeView>();
            Mapper.CreateMap<DeviceTypeView, DeviceType>();

            Mapper.CreateMap<Job, JobView>();
            Mapper.CreateMap<JobView, Job>();

            Mapper.CreateMap<Device, PrinterView>();
            Mapper.CreateMap<PrinterView, Device>();

            //Mapper.CreateMap<SettingsView, Setup>();
            //Mapper.CreateMap<Setup, SettingsView>();
        }


        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }

        public object Map(object source, object destination, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, destination, sourceType, destinationType);
        
        }
    }
}