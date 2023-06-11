using Voluncare.Core.Enums;

namespace Voluncare.Managment.ViewModels.HelpRequest
{
    public class ListResponseViewModel
    {
        public Guid UserId { get; set; }

        public Guid? TakenVolunteerId { get; set; }

        public string UserName { get; set; }

        public string? AvatarImage { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ContactNumber { get; set; }

        public DateTime CreateDate { get; set; }

        public HelpRequestStatus Status { get; set; }
    }
}
