namespace Voluncare.Managment.ViewModels.User
{
    public class UpdateUserViewModel
    {
        public Guid Id { get; set; }

        public string? AvatarImage { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
