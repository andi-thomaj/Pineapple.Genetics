using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pineapple.Genetics.domain;
using Pineapple.Genetics.domain.Shared;

namespace Pineapple.Genetics.domain.Configurations
{
    public class AreaConfiguration : BaseConfiguration, IEntityTypeConfiguration<Area>
    {
        private const int NameMaxLength = 40;
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder
                .HasKey(e => e.Id)
                .HasName("id");

            builder.Property(a => a.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder.Property(x => x.CreatedBy)
                .HasColumnName("created_by")
                .IsRequired()
                .HasMaxLength(CreatedByMaxLength);

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            builder.Property(x => x.UpdatedBy)
                .HasColumnName("updated_by")
                .IsRequired()
                .HasMaxLength(UpdatedByMaxLength);

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired();

            builder.ToTable("area");
        }
    }
}
