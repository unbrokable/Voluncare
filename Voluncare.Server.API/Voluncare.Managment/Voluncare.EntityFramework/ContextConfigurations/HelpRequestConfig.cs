using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voluncare.Core.Entities;

namespace Voluncare.EntityFramework.ContextConfigurations
{
    public class HelpRequestConfig : IEntityTypeConfiguration<HelpRequest>
    {
        public void Configure(EntityTypeBuilder<HelpRequest> builder)
        {
            builder.ToTable("HelpRequests");

            builder.HasKey(x => x.Id)
                .IsClustered();

            builder.HasOne(x => x.User)
                .WithMany(p => p.HelpRequests)
                .HasForeignKey(pt => pt.UserId);

            builder.HasOne(x => x.Organization)
                .WithMany(p => p.HelpRequests)
                .HasForeignKey(pt => pt.TakenOrganizationId)
                .IsRequired(false);

            builder.HasOne(x => x.User)
                .WithMany(p => p.HelpRequests)
                .HasForeignKey(pt => pt.TakenVolunteerId)
                .IsRequired(false);
        }
    }
}
