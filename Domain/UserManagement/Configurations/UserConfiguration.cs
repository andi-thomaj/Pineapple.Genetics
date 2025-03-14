using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.UserManagement.Configurations
{
    public class UserConfiguration : BaseConfiguration, IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(x => x.FirstName)
                .IsRequired(Settings.No)
                .HasMaxLength(Settings.FirstNameMaxLength);

            builder.Property(x => x.MiddleName)
                .IsRequired(Settings.No)
                .HasMaxLength(Settings.MiddleNameMaxLength);

            builder.Property(x => x.LastName)
                .IsRequired(Settings.No)
                .HasMaxLength(Settings.LastNameMaxLength);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(Settings.EmailMaxLength);

            builder.Property(x => x.Password)
                .IsRequired(Settings.No)
                .HasMaxLength(Settings.PasswordMaxLength);

            builder.Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(Settings.UsernameMaxLength);

            builder.Property(x => x.Settings)
                .HasColumnType("jsonb")
                .IsRequired(Settings.No);

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
                .Navigation(x => x.Role)
                .AutoInclude();

            builder.HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId)
                .HasConstraintName("FK_users_tb_roleId_TO_roles_tb");

            builder.ToTable("users_tb");
        }
        public class Settings
        {
            public const int FirstNameMaxLength = 50;
            public const int MiddleNameMaxLength = 50;
            public const int LastNameMaxLength = 50;
            public const int UsernameMinLength = 5;
            public const int UsernameMaxLength = 50;
            public const int EmailMaxLength = 50;
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 16;
            public const bool No = false;
        }
    }
}
