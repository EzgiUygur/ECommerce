using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Application.Orders.GetOrders
{
    public class GetOrdersQuery : BaseQuery<List<GetOrderDto>>
    {
        /*
         * User auth. akışı olmadığı için "UserId" request parameter olarak alınıyor.
         * Eğer JWT akışı olsaydı claim'lerden alınması gerekirdi.
         */
        [FromQuery(Name = "userId")]
        public long? UserId { get; set; }
    }
}
