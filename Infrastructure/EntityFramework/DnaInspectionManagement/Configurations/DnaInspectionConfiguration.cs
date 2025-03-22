using Domain.DnaInspectionManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.DnaInspectionManagement.Configurations
{
    public class DnaInspectionConfiguration : BaseConfiguration, IEntityTypeConfiguration<DnaInspection>
    {
        public void Configure(EntityTypeBuilder<DnaInspection> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(x => x.Coordinates)
                .IsRequired(Settings.No)
                .HasMaxLength(Settings.CoordinatesMaxLength);

            builder.Property(x => x.FileName)
                .IsRequired()
                .HasMaxLength(Settings.FileNameMaxLength);

            builder.Property(x => x.GeneticFile)
                .IsRequired()
                .HasMaxLength(Settings.GeneticFileMaxLength);

            builder.Property(x => x.IsDeleted)
                .IsRequired();

            builder.Property(x => x.CreatedBy)
                .IsRequired()
                .HasMaxLength(CreatedByMaxLength);

            builder.Property(x => x.CreatedAt)
                .IsRequired();

            builder.Property(x => x.UpdatedBy)
                .IsRequired()
                .HasMaxLength(UpdatedByMaxLength);

            builder.Property(x => x.UpdatedAt)
                .IsRequired();

            builder.HasMany(x => x.Countries)
                .WithMany(x => x.DnaInspections);

            builder.ToTable("dnaInspections_tb");
        }

        public class Settings
        {
            public const int CoordinatesMaxLength = 200;
            public const int FileNameMaxLength = 100;
            public const int GeneticFileMaxLength = 5242880; // 5 MB
            public const bool No = false;
        }
    }
}
