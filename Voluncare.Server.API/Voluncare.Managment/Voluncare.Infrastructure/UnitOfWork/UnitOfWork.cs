using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voluncare.Core.Entities;
using Voluncare.Core.Interfaces;
using Voluncare.EntityFramework.Context;
using Voluncare.Infrastructure.Repository;

namespace Voluncare.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VoluncareDbContext context;

        public UnitOfWork(VoluncareDbContext context)
        {
            this.context = context;

            UserRepository = new Repository<ApplicationUser>(context);
            ChatRepository = new Repository<Chat>(context);
            CommentRepository = new Repository<Comment>(context);
            EstimateRepository = new Repository<Estimate>(context);
            HelpRequestRepository = new Repository<HelpRequest>(context);
            MessageRepository = new Repository<Message>(context);
            OrganizationContactRepository = new Repository<OrganizationContact>(context);
            StaffRepository = new Repository<Staff>(context);
            VolunteerOrganizationRepository = new Repository<VolunteerOrganization>(context);
        }

        public IRepository<ApplicationUser> UserRepository { get; private set; }

        public IRepository<Chat> ChatRepository { get; private set; }

        public IRepository<Comment> CommentRepository  { get; private set; }

        public IRepository<Estimate> EstimateRepository  { get; private set; }

        public IRepository<HelpRequest> HelpRequestRepository  { get; private set; }

        public IRepository<Message> MessageRepository { get; private set; }

        public IRepository<OrganizationContact> OrganizationContactRepository  { get; private set; }

        public IRepository<Staff> StaffRepository  { get; private set; }

        public IRepository<VolunteerOrganization> VolunteerOrganizationRepository  { get; private set; }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public Task Save()
        {
            return this.context.SaveChangesAsync();
        }
    }
}
