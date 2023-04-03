using ECommerce.Api.Messaging;
using ECommerce.Application.Orders.CancelOrder;
using ECommerce.Application.Orders.DeliverOrder;
using ECommerce.Application.Orders.GetOrder;
using ECommerce.Application.Orders.GetOrderLines;
using ECommerce.Application.Orders.GetOrders;
using ECommerce.Application.Orders.InProgressOrder;
using ECommerce.Application.Orders.InsertOrder;
using ECommerce.Application.Orders.InTransitOrder;
using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    public class OrdersController : BaseController
    {
        private readonly ICQRSProcessor _processor;

        public OrdersController(ICQRSProcessor processor)
        {
            this._processor = processor;
        }

        /// <summary>
        /// Get All Orders
        /// </summary>
        /// <response code="200">if response code is 200(Success) return <see cref="GetOrderDto"/></response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("")]
        [ProducesResponseType(typeof(List<GetOrderDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Response<List<GetOrderDto>>> GetOrders(
            [FromQuery] GetOrdersQuery request,
            CancellationToken cancellationToken)
        {
            var result = await this._processor.SendAsync(request, cancellationToken);
            return this.ProduceResponse(result);
        }

        /// <summary>
        /// Get Order By Id
        /// </summary>
        /// <response code="200">if response code is 200(Success) return <see cref="GetOrderDto"/></response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("{orderNumber}")]
        [ProducesResponseType(typeof(GetOrderDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Response<GetOrderDto>> GetOrder(
            [FromRoute] string orderNumber,
            CancellationToken cancellationToken)
        {
            var result = await this._processor.SendAsync(new GetOrderQuery(orderNumber), cancellationToken);
            return this.ProduceResponse(result);
        }

        /// <summary>
        /// Get Order Lines
        /// </summary>
        /// <response code="200">if response code is 200(Success) return <see cref="GetOrderLineDto"/></response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("{orderNumber}/lines")]
        [ProducesResponseType(typeof(List<GetOrderLineDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Response<List<GetOrderLineDto>>> GetOrderLines(
            [FromRoute] string orderNumber,
            CancellationToken cancellationToken)
        {
            var result = await this._processor.SendAsync(new GetOrderLinesQuery(orderNumber), cancellationToken);
            return this.ProduceResponse(result);
        }

        /// <summary>
        /// Insert Order
        /// </summary>
        /// <response code="200">if response code is 200(Success) return <see cref="OrderDto"/></response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost("")]
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Response<OrderDto>> InsertOrder(
            [FromBody] InsertOrderCommand request,
            CancellationToken cancellationToken)
        {
            var result = await this._processor.SendAsync(request, cancellationToken);
            return this.ProduceResponse(result);
        }

        /// <summary>
        /// InProgress Order
        /// </summary>
        /// <response code="200">if response code is 200(Success) return <see cref="OrderDto"/></response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut("{orderNumber}/inprogress")]
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Response<OrderDto>> InProgressOrder(
            [FromRoute] string orderNumber,
            CancellationToken cancellationToken)
        {
            var result = await this._processor.SendAsync(new InProgressOrderCommand(orderNumber), cancellationToken);
            return this.ProduceResponse(result);
        }

        /// <summary>
        /// InTransit Order
        /// </summary>
        /// <response code="200">if response code is 200(Success) return <see cref="OrderDto"/></response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut("{orderNumber}/intransit")]
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Response<OrderDto>> InTransitOrder(
            [FromRoute] string orderNumber,
            CancellationToken cancellationToken)
        {
            var result = await this._processor.SendAsync(new InTransitOrderCommand(orderNumber), cancellationToken);
            return this.ProduceResponse(result);
        }

        /// <summary>
        /// Deliver Order
        /// </summary>
        /// <response code="200">if response code is 200(Success) return <see cref="OrderDto"/></response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut("{orderNumber}/deliver")]
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Response<OrderDto>> DeliverOrder(
            [FromRoute] string orderNumber,
            CancellationToken cancellationToken)
        {
            var result = await this._processor.SendAsync(new DeliverOrderCommand(orderNumber), cancellationToken);
            return this.ProduceResponse(result);
        }

        /// <summary>
        /// Cancel Order
        /// </summary>
        /// <response code="200">if response code is 200(Success) return <see cref="OrderDto"/></response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut("{orderNumber}/cancel")]
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Response<OrderDto>> CancelOrder(
            [FromRoute] string orderNumber,
            CancellationToken cancellationToken)
        {
            var result = await this._processor.SendAsync(new CancelOrderCommand(orderNumber), cancellationToken);
            return this.ProduceResponse(result);
        }
    }
}
