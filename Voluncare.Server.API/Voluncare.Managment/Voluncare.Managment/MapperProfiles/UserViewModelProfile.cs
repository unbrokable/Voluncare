using AutoMapper;
using Voluncare.Core.Entities;
using Voluncare.Managment.ViewModels;

namespace Voluncare.Managment.MapperProfiles
{
    public class UserViewModelProfile : Profile
    {
        public UserViewModelProfile()
        {
            CreateMap<UserViewModel, ApplicationUser>().ReverseMap();
        }
    }
}
