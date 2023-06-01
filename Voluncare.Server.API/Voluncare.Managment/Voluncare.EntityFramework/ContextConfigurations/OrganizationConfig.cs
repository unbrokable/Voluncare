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
    public class OrganizationConfig : IEntityTypeConfiguration<VolunteerOrganization>
    {
        public void Configure(EntityTypeBuilder<VolunteerOrganization> builder)
        {
            builder.ToTable("VolunteerOrganizations");

            builder.HasKey(x => x.Id)
                .IsClustered();

            builder.HasOne(x => x.Founder)
                .WithMany(p => p.OwnedOrganizations)
                .HasForeignKey(pt => pt.FounderId);
        }
    }
}
