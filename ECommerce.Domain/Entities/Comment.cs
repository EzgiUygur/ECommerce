using System.ComponentModel.DataAnnotations;
using ECommerce.Core.Data;

namespace ECommerce.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public long UserId { get; set; }

        public long ProductId { get; set; }

        public string Message { get; set; }

        #region Navigation Properties
        [Required]
        public User User { get; set; }

        [Required]
        public Product Product { get; set; }
        #endregion
    }
}
