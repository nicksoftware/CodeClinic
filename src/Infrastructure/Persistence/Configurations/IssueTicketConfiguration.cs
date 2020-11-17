using CodeClinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeClinic.Infrastructure.Persistence.Configurations
{
    public class IssueTicketConfiguration : IEntityTypeConfiguration<IssueTicket>
    {
        public void Configure(EntityTypeBuilder<IssueTicket> builder)
        {
            builder.Property(t => t.Title)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
