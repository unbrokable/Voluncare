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
    public class StaffConfig : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.ToTable("Staffs");

            builder.HasKey(x => x.Id)
                .IsClustered();

            builder.HasOne(x => x.User)
                .WithMany(p => p.Staffs)
                .HasForeignKey(pt => pt.UserId);

            builder.HasOne(x => x.Organization)
                .WithMany(p => p.Staffs)
                .HasForeignKey(pt => pt.OrganizationId);
        }
    }
}
