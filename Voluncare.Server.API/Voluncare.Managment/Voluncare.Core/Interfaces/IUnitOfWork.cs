using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voluncare.Core.Entities;

namespace Voluncare.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<ApplicationUser> UserRepository { get; }

        IRepository<Chat> ChatRepository { get; }

        IRepository<Comment> CommentRepository { get; }

        IRepository<Estimate> EstimateRepository { get; }

        IRepository<HelpRequest> HelpRequestRepository { get; }

        IRepository<Message> MessageRepository { get; }

        IRepository<OrganizationContact> OrganizationContactRepository { get; }

        IRepository<Staff> StaffRepository { get; }

        IRepository<VolunteerOrganization> VolunteerOrganizationRepository { get; }

        Task Save();
    }
}
