using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Infostructure.Configs
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(user => user.AccountBalance)
                .HasDefaultValue(0)
                .IsRequired();
            builder
                .Property(user => user.UserName)
                .IsRequired();
            builder
                .Property(user => user.FirstName)
                .IsRequired();
            builder
                .Property(user => user.SecondName)
                .IsRequired();
            builder
                .Property(user => user.Email)
                .HasDefaultValue(null);
            builder
                .HasIndex(user => user.Email)
                .IsUnique();
            builder
                .Property(user => user.PhoneNumber)
                .HasDefaultValue(null);
            builder
                .HasIndex(user => user.PhoneNumber)
                .IsUnique();
            builder
                .HasIndex(user => user.Age)
                .IsUnique();
        }
    }
}
