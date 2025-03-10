using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class UserConfiguration : BaseConfiguration, IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(e => e.Id)
                .HasName("id");

            builder.Property(x => x.FirstName)
                .HasColumnName("first_name")
                .IsRequired(Settings.No)
                .HasMaxLength(Settings.FirstNameMaxLength);

            builder.Property(x => x.MiddleName)
                .HasColumnName("middle_name")
                .IsRequired(Settings.No)
                .HasMaxLength(Settings.MiddleNameMaxLength);

            builder.Property(x => x.LastName)
                .HasColumnName("last_name")
                .IsRequired(Settings.No)
                .HasMaxLength(Settings.LastNameMaxLength);

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(Settings.EmailMaxLength);

            builder.Property(x => x.Password)
                .HasColumnName("password")
                .IsRequired(Settings.No)
                .HasMaxLength(Settings.PasswordMaxLength);

            builder.Property(x => x.Username)
                .HasColumnName("username")
                .IsRequired()
                .HasMaxLength(Settings.Username);

            builder.Property(x => x.Settings)
                .HasColumnName("settings")
                .HasColumnType("jsonb")
                .IsRequired(Settings.No);

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

            builder.ToTable("users_tb");
        }
        public static class Settings
        {
            public const int FirstNameMaxLength = 50;
            public const int MiddleNameMaxLength = 50;
            public const int LastNameMaxLength = 50;
            public const int Username = 50;
            public const int EmailMaxLength = 50;
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 16;
            public const bool No = false;
        }
    }
}
