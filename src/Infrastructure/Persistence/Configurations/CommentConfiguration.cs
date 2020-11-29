using CodeClinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeClinic.Infrastructure.Persistence.Configurations
{
    class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {

            builder.Property(t => t.Title);
            builder
                .Property(c => c.Description)
                .IsRequired();


            builder.HasOne(x => x.IssueTicket)
                .WithMany(d => d.Comments)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(k => k.IssueTicketId)
                .IsRequired();

            builder.HasMany(x => x.Likes)
                .WithOne(d=> d.Comment).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
