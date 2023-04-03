using System.ComponentModel.DataAnnotations;
using ECommerce.Core.Data;
using ECommerce.Domain.Enums;

namespace ECommerce.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string OrderNumber { get; set; }

        public OrderStatus Status { get; set; }

        public string Note { get; set; }

        public long UserId { get; set; }

        #region Navigation Properties
        [Required]
        public User User { get; set; }

        public IList<OrderLine> OrderLines { get; set; }
        #endregion
    }
}
