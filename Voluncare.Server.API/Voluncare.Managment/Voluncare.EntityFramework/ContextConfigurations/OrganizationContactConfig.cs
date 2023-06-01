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
    public class OrganizationContactConfig : IEntityTypeConfiguration<OrganizationContact>
    {
        public void Configure(EntityTypeBuilder<OrganizationContact> builder)
        {
            builder.ToTable("OrganizationContacts");

            builder.HasKey(x => x.Id)
                .IsClustered();

            builder.HasOne(x => x.Organization)
                .WithMany(p => p.OrganizationContacts)
                .HasForeignKey(pt => pt.OrganizationId);
        }
    }
}
