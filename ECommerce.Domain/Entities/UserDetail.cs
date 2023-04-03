using System.ComponentModel.DataAnnotations;
using ECommerce.Core.Data;
using ECommerce.Domain.Enums;

namespace ECommerce.Domain.Entities
{
    public class UserDetail : BaseEntity
    {
        public string PhoneNumber { get; set; }

        public string WorkPhoneNumber { get; set; }

        public Gender Gender { get; set; }

        public string Address { get; set; }

        public DateTime BirthDate { get; set; }

        public long UserId { get; set; }

        #region Navigation Properties
        [Required]
        public User User { get; set; }
        #endregion
    }
}
