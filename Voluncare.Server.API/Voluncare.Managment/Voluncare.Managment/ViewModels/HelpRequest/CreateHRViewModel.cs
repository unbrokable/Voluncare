namespace Voluncare.Managment.ViewModels.HelpRequest
{
    public class CreateHRViewModel
    {
        public Guid TakenOrganizationId { get; set; }

        public Guid TakenVolunteerId { get; set; }

        public Guid UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ContactNumber { get; set; }
    }
}
