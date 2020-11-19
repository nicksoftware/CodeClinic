using CodeClinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeClinic.Infrastructure.Persistence.Configurations
{
    class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {

            builder.Property(t => t.Title);
            builder
                .Property(c => c.Description)
                .IsRequired();


            builder.HasOne(x => x.IssueTicket)
                .WithMany(d => d.Reviews)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(k => k.IssueTicketId)
                .IsRequired();

        }
    }
}
