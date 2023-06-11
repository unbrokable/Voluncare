using Voluncare.Core.Enums;

namespace Voluncare.Managment.ViewModels.HelpRequest
{
    public class ListResponseViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ContactNumber { get; set; }

        public DateTime CreateDate { get; set; }

        public HelpRequestStatus Status { get; set; }
    }
}
