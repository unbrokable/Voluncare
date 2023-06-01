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
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");

            builder.HasKey(x => x.Id)
                .IsClustered();

            builder.HasOne(x => x.User)
                .WithMany(p => p.Comments)
                .HasForeignKey(pt => pt.UserId);

            builder.HasOne(x => x.Organization)
                .WithMany(p => p.Comments)
                .HasForeignKey(pt => pt.OrganizationId)
                .IsRequired(false);
        }
    }
}
