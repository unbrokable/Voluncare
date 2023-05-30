using Voluncare.Core.Enums;

namespace Voluncare.Managment.ViewModels.User
{
    public class RegisterUserViewModel
    {
        public ApllicationUserType ApllicationUserType { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }
    }
}
