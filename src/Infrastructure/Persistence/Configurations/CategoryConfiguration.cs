using CodeClinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeClinic.Infrastructure.Persistence.Configurations
{
    class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(n => n.Name)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(d => d.Description)
                .HasMaxLength(500);
        }
    }
}
