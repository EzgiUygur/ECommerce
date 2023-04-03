using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Application.Products.GetProducts
{
    public class GetProductsQuery : BaseQuery<List<GetProductDto>>
    {
        [FromQuery(Name = "name")]
        public string Name { get; set; }
    }
}
