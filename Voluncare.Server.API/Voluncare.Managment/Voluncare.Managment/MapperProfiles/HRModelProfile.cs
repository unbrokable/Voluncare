using AutoMapper;
using Voluncare.Core.Entities;
using Voluncare.Managment.ViewModels.HelpRequest;

namespace Voluncare.Managment.MapperProfiles
{
    public class HRModelProfile : Profile
    {
        public HRModelProfile()
        {
            CreateMap<CreateHRViewModel, HelpRequest>().ReverseMap();

            CreateMap<TakeRequestViewModel, HelpRequest>().ReverseMap();

            CreateMap<ListResponseViewModel, HelpRequest>().ReverseMap()
                .ForMember(dest => dest.HelpRequestId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.AvatarImage, opt => opt.MapFrom(src => src.User.AvatarImage));

            //CreateMap<List<ListResponseViewModel>, List<HelpRequest>>().ReverseMap();
        }
    }
}
