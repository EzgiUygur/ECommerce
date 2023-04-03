using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Domain.Configurations
{
    public class UserDetailConfiguration : IEntityTypeConfiguration<UserDetail>
    {
        public void Configure(EntityTypeBuilder<UserDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.PhoneNumber).HasColumnName("PhoneNumber");
            builder.Property(x => x.WorkPhoneNumber).HasColumnName("WorkPhoneNumber");
            builder.Property(x => x.Gender).HasColumnName("Gender");
            builder.Property(x => x.Address).HasColumnName("Address");
            builder.Property(x => x.BirthDate).HasColumnName("BirthDate");

            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(x => x.IsDeleted).HasColumnName("IsDeleted");

            builder.HasOne(x => x.User).WithOne(x => x.UserDetail).HasForeignKey<UserDetail>(x => x.UserId);
        }
    }
}
