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
            Mapper.CreateMap<SizePaperView, SizePaper>()
               .ForMember(dest => dest.Height_cm, opt => opt.MapFrom(src => src.Height_cm))
               .ForMember(dest => dest.Width_cm, opt => opt.MapFrom(src => src.Width_cm));
            Mapper.CreateMap<SizePaper, SizePaperView>()
               .ForMember(dest => dest.Height_cm, opt => opt.MapFrom(src => src.Height_cm))
               .ForMember(dest => dest.Width_cm, opt => opt.MapFrom(src => src.Width_cm));

            Mapper.CreateMap<DeviceType, DeviceTypeView>();
            Mapper.CreateMap<DeviceTypeView, DeviceType>();

            Mapper.CreateMap<PrintKind, PrintKindView>();
            Mapper.CreateMap<PrintKindView, PrintKind>();

            Mapper.CreateMap<Job, JobView>();
            Mapper.CreateMap<JobView, Job>();

            Mapper.CreateMap<Device, DeviceView>();
            Mapper.CreateMap<DeviceView, Device>();

            Mapper.CreateMap<PaperType, PaperTypeView>();
            Mapper.CreateMap<PaperTypeView,PaperType>();

            Mapper.CreateMap<CartridgeColor, CartridgeColorView>();
            Mapper.CreateMap<CartridgeColorView, CartridgeColor>();

            Mapper.CreateMap<Application, ApplicationView>();
            Mapper.CreateMap<ApplicationView, Application>();

            Mapper.CreateMap<Department, DepartmentView>();
            Mapper.CreateMap<DepartmentView, Department>();

            Mapper.CreateMap<Employee, EmployeeView>();
            Mapper.CreateMap<EmployeeView, Employee>();

            //Mapper.CreateMap<SettingsView, Setup>();
            //Mapper.CreateMap<Setup, SettingsView>();

            Mapper.CreateMap<Settings,FieldSettingView>();
            Mapper.CreateMap<FieldSettingView, Settings>();

            Mapper.CreateMap<Tag, TagView>()
                .ForMember(dest => dest.Tag1, opt => opt.MapFrom(src => src.Tag1))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
            Mapper.CreateMap<TagView, Tag>()
                .ForMember(dest => dest.Tag1, opt => opt.MapFrom(src => src.Tag1))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
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