using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pineapple.Genetics.api.Data.Entities.Shared;

namespace Pineapple.Genetics.api.Data.Entities.Configurations
{
    public class RawDnaConfiguration : BaseConfiguration, IEntityTypeConfiguration<RawDna>
    {
        private const int GeneticFileMaxLength = 1048576; // 1MB
        private const int NameMaxLength = 40;
        public void Configure(EntityTypeBuilder<RawDna> builder)
        {
            builder
                .HasKey(e => e.Id)
                .HasName("id");

            builder.Property(x => x.FileName)
                .HasColumnName("file_name")
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder.Property(e => e.GeneticFile)
                .HasColumnName("genetic_file")
                .IsRequired()
                .HasMaxLength(GeneticFileMaxLength);

            builder.Property(e => e.IsDeleted)
                .HasColumnName("is_deleted")
                .IsRequired();

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

            builder.ToTable("raw_dna");
        }
    }
}
