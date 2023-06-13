using AutoMapper;
using Voluncare.Core.Entities;
using Voluncare.Managment.ViewModels.Estimate;

namespace Voluncare.Managment.MapperProfiles
{
    public class EstimateProfile : Profile
    {
        public EstimateProfile()
        {
            CreateMap<EstimateVolunteerViewModel, Estimate>().ReverseMap();

            CreateMap<EstimateVolunteerViewModel, Estimate>().ReverseMap();
        }
    }
}
