using Voluncare.Core.Entities;

namespace Voluncare.Managment.ViewModels.Volunteer
{
    public class VolunteerBaseInfoViewModel
    {
        public Guid Id { get; set; }

        public string? AvatarImage { get; set; }

        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        public double AverageRating { get; set; }

        public double TrustLevel { get; set; }
    }
}
