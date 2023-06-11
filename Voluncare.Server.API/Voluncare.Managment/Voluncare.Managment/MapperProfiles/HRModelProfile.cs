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
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));

            //CreateMap<List<ListResponseViewModel>, List<HelpRequest>>().ReverseMap();
        }
    }
}
