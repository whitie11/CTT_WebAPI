using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Users;
using WebApi.Models.Diary;
using  WebApi.Models.Patients;
using WebApi.Entities2;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Users, UserModel>();
            CreateMap<RegisterModel, Users>();
            CreateMap<UpdateModel, Users>();

            CreateMap< Clinics, ClinicDTO>()
            .ForMember(dest => dest.ClinicId, opt => opt.MapFrom(src => src.ClinicId))
            .ForMember(dest => dest.ClinicName, opt => opt.MapFrom(src => src.ClinicName))
            ;

            CreateMap<Patients, PatientDTO>();

           // CreateMap<Appointment, ApptDTO>();
        }
    }
}