using AutoMapper;
using Company.Models;
using Company.Services.Messages;
using Company.Services.Request;

namespace Company.Services.Profiles
{
    /// <summary>
    /// Profile para el modelo de usuarios
    /// </summary>
    public class UserAppProfile : Profile
    {
        public UserAppProfile()
        {
            CreateMap<UserRequest, UserApp>()
              .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => src.Date))
              .ForMember(dest => dest.DateModified, opt => opt.Ignore())
              .ForMember(dest => dest.Language, opt => opt.Ignore())
              .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.Language))
              .ForMember(dest => dest.LastAdmissionDate, opt => opt.MapFrom(src => src.LastAdmissionDate))
              .ForMember(dest => dest.NumberOfAttemps, opt => opt.MapFrom(src => src.NumberOfAttemps))
              .ForMember(dest => dest.Pw, opt => opt.MapFrom(src => src.Pw))
              .ForMember(dest => dest.RestoreKey, opt => opt.MapFrom(src => src.RestoreKey))
              .ForMember(dest => dest.UserCreatedId, opt => opt.MapFrom(src => src.CreateId))
              .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.UserInfoDetail, opt => opt.Ignore())
              .ForMember(dest => dest.UserMail, opt => opt.MapFrom(src => src.Mail))
              .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Name))
              .ForMember(dest => dest.UserRoles, opt => opt.Ignore())
              .ForMember(dest => dest.UserStatus, opt => opt.Ignore())
              .ForMember(dest => dest.UserStatusId, opt => opt.MapFrom(src => src.Status))
              .ForMember(dest => dest.UserUpdateId, opt => opt.Ignore())
              ;

            CreateMap<UserApp, UserResponse>()
             .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => src.DateCreated))
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
             .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.LanguageId))
             .ForMember(dest => dest.LastAdmissionDate, opt => opt.MapFrom(src => src.LastAdmissionDate))
             .ForMember(dest => dest.Mail, opt => opt.MapFrom(src => src.UserMail))
             .ForMember(dest => dest.RestoreKey, opt => opt.MapFrom(src => src.RestoreKey))
             .ForMember(dest => dest.StatusValue, opt => opt.MapFrom(src => src.UserStatusId))
             .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
             .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.UserStatus != null ? src.UserStatus.UserStatusDescriptions : string.Empty))
             ;
        }
    }
}