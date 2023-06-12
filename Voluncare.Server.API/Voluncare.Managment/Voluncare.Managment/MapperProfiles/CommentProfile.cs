using AutoMapper;
using Voluncare.Core.Entities;
using Voluncare.Managment.ViewModels.Comments;

namespace Voluncare.Managment.MapperProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CreateCommentViewModel, Comment>().ReverseMap();

            CreateMap<CommentResponseViewModel, Comment>().ReverseMap()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));
        }
    }
}
