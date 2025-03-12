using Domain.DnaInspectionManagement;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.DnaInspectionManagement.Configurations
{
    public class AreaConfiguration : BaseConfiguration, IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(Settings.NameMaxLength);

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

            builder
                .HasOne(x => x.Country)
                .WithMany(x => x.Areas)
                .HasForeignKey(x => x.CountryId)
                .HasConstraintName("FK_areas_tb_countryId_TO_countries_tb");

            builder.ToTable("areas_tb");
        }

        public class Settings
        {
            public const int NameMaxLength = 40;
        }
    }
}
