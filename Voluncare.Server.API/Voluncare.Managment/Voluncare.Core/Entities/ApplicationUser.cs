using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voluncare.Core.Enums;
using Voluncare.Core.Interfaces;

namespace Voluncare.Core.Entities
{
    public class ApplicationUser : IdentityUser<Guid>, IDbEntity
    {
        public ApllicationUserType ApllicationUserType { get; set; }

        public string? AvatarImage { get; set; }

        public List<Chat> Chats { get; set; }

        public List<HelpRequest> HelpRequests { get; set; }

        public List<Staff> Staffs { get; set; }

        public List<VolunteerOrganization> OwnedOrganizations { get; set; }

        public List<Estimate> Estimates { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
