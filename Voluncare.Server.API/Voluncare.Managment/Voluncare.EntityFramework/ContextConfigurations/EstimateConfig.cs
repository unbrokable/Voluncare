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
    public class EstimateConfig : IEntityTypeConfiguration<Estimate>
    {
        public void Configure(EntityTypeBuilder<Estimate> builder)
        {
            builder.ToTable("Estimates");

            builder.HasKey(x => x.Id)
                .IsClustered();

            builder.HasOne(x => x.User)
                .WithMany(p => p.Estimates)
                .HasForeignKey(pt => pt.UserId)
                .IsRequired(false);

            builder.HasOne(x => x.Organization)
                .WithMany(p => p.Estimates)
                .HasForeignKey(pt => pt.OrganizationId)
                .IsRequired(false);
        }
    }
}
