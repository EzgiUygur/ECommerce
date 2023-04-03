using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Commands;

namespace ECommerce.Application.Products.InsertProduct
{
    public class InsertProductCommand : BaseCommand<GenericIdDto>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public uint Stock { get; set; }

        public string ImageUrl { get; set; }
    }
}
