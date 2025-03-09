using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pineapple.Genetics.domain;
using Pineapple.Genetics.domain.Shared;

namespace Pineapple.Genetics.domain.Configurations
{
    public class UserConfiguration : BaseConfiguration, IEntityTypeConfiguration<User>
    {
        private const int FirstNameMaxLength = 50;
        private const int MiddleNameMaxLength = 50;
        private const int LastNameMaxLength = 50;
        private const int Username = 50;
        private const int EmailMaxLength = 50;
        private const int PasswordMaxLength = 16;
        private const bool No = false;
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(e => e.Id)
                .HasName("id");

            builder.Property(x => x.FirstName)
                .HasColumnName("first_name")
                .IsRequired(No)
                .HasMaxLength(FirstNameMaxLength);

            builder.Property(x => x.MiddleName)
                .HasColumnName("middle_name")
                .IsRequired(No)
                .HasMaxLength(MiddleNameMaxLength);

            builder.Property(x => x.LastName)
                .HasColumnName("last_name")
                .IsRequired(No)
                .HasMaxLength(LastNameMaxLength);

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(EmailMaxLength);

            builder.Property(x => x.Password)
                .HasColumnName("password")
                .IsRequired(No)
                .HasMaxLength(PasswordMaxLength);

            builder.Property(x => x.Username)
                .HasColumnName("username")
                .IsRequired()
                .HasMaxLength(Username);

            builder.Property(x => x.Settings)
                .HasColumnName("settings")
                .HasColumnType("jsonb")
                .IsRequired(No);

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
    }
}
