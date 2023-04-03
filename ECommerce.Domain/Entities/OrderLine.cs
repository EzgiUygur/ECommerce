using System.ComponentModel.DataAnnotations;
using ECommerce.Core.Data;

namespace ECommerce.Domain.Entities
{
    public class OrderLine : BaseEntity
    {
        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public long ProductId { get; set; }

        public long OrderId { get; set; }

        #region Navigation Properties
        [Required]
        public Order Order { get; set; }

        [Required]
        public Product Product { get; set; }
        #endregion
    }
}
