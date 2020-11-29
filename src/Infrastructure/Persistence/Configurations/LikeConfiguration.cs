using CodeClinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeClinic.Infrastructure.Persistence.Configurations
{
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder
                .Property(d => d.CommentId)
                .IsRequired();
            
            builder
                .Property(d => d.CreatedBy)
                .IsRequired();
            
            builder.HasOne(c => c.Comment)
                .WithMany(cm => cm.Likes).HasForeignKey(k => k.CommentId);

        }
    }

}
