using Domain.UserManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.UserManagement.Configurations
{
    public class RoleConfiguration : BaseConfiguration, IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(x => x.Name)
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

            builder.ToTable("roles_tb");
        }

        public class Settings
        {
            public const int NameMaxLength = 50;
        }
    }
}
