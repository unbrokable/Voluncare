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

            CreateMap<ListResponseViewModel, HelpRequest>().ReverseMap();

            CreateMap<List<ListResponseViewModel>, List<HelpRequest>>().ReverseMap();
        }
    }
}
