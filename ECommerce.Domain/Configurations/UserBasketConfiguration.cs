using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Domain.Configurations
{
    public class UserBasketConfiguration : IEntityTypeConfiguration<UserBasket>
    {
        public void Configure(EntityTypeBuilder<UserBasket> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(x => x.IsDeleted).HasColumnName("IsDeleted");

            builder.HasOne(x => x.User).WithMany(x => x.Baskets).HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Product).WithMany(x => x.Baskets).HasForeignKey(x => x.ProductId);
        }
    }
}
