using System.ComponentModel.DataAnnotations;
using ECommerce.Core.Data;

namespace ECommerce.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public long RoleId { get; set; }

        #region Navigation Properties
        [Required]
        public Role Role { get; set; }

        public UserDetail UserDetail { get; set; }

        public IList<Order> Orders { get; set; }

        public IList<Comment> Comments { get; set; }

        public IList<UserBasket> Baskets { get; set; }
        #endregion
    }
}
