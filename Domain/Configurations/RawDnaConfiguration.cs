﻿using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class RawDnaConfiguration : BaseConfiguration, IEntityTypeConfiguration<RawDna>
    {
        public void Configure(EntityTypeBuilder<RawDna> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(x => x.FileName)
                .IsRequired()
                .HasMaxLength(Settings.NameMaxLength);

            builder.Property(e => e.GeneticFile)
                .IsRequired()
                .HasMaxLength(Settings.GeneticFileMaxLength);

            builder.Property(e => e.IsDeleted)
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

            builder.ToTable("rawDnas_tb");
        }

        public class Settings
        {
            public const int NameMaxLength = 40;
            public const int GeneticFileMaxLength = 1048576; // 1MB
        }
    }
}
