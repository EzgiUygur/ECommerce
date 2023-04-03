using ECommerce.Core.Data;

namespace ECommerce.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        #region Navigation Properties
        public IList<User> Users { get; set; }
        #endregion
    }
}
