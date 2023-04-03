using ECommerce.Core.Data;

namespace ECommerce.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string ImageUrl { get; set; }

        #region NavigationProperties
        public IList<Comment> Comments { get; set; }

        public IList<OrderLine> OrderLines { get; set; }

        public IList<UserBasket> Baskets { get; set; }
        #endregion
    }
}
