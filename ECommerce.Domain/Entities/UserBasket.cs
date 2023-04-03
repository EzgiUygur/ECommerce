using System.ComponentModel.DataAnnotations;
using ECommerce.Core.Data;

namespace ECommerce.Domain.Entities
{
    public class UserBasket : BaseEntity
    {
        public int Quantity { get; set; }

        public long UserId { get; set; }

        public long ProductId { get; set; }

        #region Navigation Properties
        [Required]
        public User User { get; set; }

        [Required]
        public Product Product { get; set; }
        #endregion
    }
}
