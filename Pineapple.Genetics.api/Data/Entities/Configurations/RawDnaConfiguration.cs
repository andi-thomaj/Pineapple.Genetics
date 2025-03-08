using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pineapple.Genetics.api.Data.Entities.Configurations
{
    public class RawDnaConfiguration : IEntityTypeConfiguration<RawDna>
    {
        public const int GeneticFileMaxLength = 1048576; // 1MB
        public const int NameMaxLength = 40;
        public void Configure(EntityTypeBuilder<RawDna> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.GeneticFile)
                .IsRequired()
                .HasMaxLength(GeneticFileMaxLength);

            builder.Property(e => e.IsDeleted)
                .IsRequired();

            builder.Property(x => x.FileName)
                .IsRequired()
                .HasMaxLength(NameMaxLength);
        }
    }
}
