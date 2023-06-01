using AutoMapper;
using Voluncare.Core.Entities;
using Voluncare.Managment.ViewModels.User;

namespace Voluncare.Managment.MapperProfiles
{
    public class UserViewModelProfile : Profile
    {
        public UserViewModelProfile()
        {
            CreateMap<RegisterUserViewModel, ApplicationUser>().ReverseMap();

            CreateMap<UpdateUserViewModel, ApplicationUser>().ReverseMap();
        }
    }
}
