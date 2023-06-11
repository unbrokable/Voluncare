using AutoMapper;
using Voluncare.Core.Entities;
using Voluncare.Managment.ViewModels.Volunteer;

namespace Voluncare.Managment.MapperProfiles
{
    public class VolunteerProfile : Profile
    {
        public VolunteerProfile()
        {
            CreateMap<VolunteerBaseInfoViewModel, ApplicationUser>().ReverseMap()
                .ForMember(x => x.AverageRating, opt => opt.Ignore())
                .ForMember(x => x.TrustLevel, opt => opt.Ignore());
        }
    }
}
