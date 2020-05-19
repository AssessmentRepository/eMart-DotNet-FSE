using eMart.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eMart.DataLayer.Configurations.UserConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(pf => pf.Name).IsRequired().HasMaxLength(50);
            builder.Property(pf => pf.Email).IsRequired().HasMaxLength(50);
            builder.Property(pf => pf.PhoneNumber).IsRequired().HasMaxLength(50);
            builder.Property(pf => pf.Password).IsRequired().HasMaxLength(15);
        }
    }
}