using ECommerce.Api.Messaging;
using ECommerce.Application.Products.GetProduct;
using ECommerce.Application.Products.GetProducts;
using ECommerce.Application.Products.InsertProduct;
using ECommerce.Application.Products.UpdateProduct;
using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly ICQRSProcessor _processor;

        public ProductsController(ICQRSProcessor processor)
        {
            this._processor = processor;
        }

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <response code="200">if response code is 200(Success) return <see cref="GetProductDto"/></response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("")]
        [ProducesResponseType(typeof(List<GetProductDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Response<List<GetProductDto>>> GetProducts(
            [FromQuery] GetProductsQuery request,
            CancellationToken cancellationToken)
        {
            var result = await this._processor.SendAsync(request, cancellationToken);
            return this.ProduceResponse(result);
        }

        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <response code="200">if response code is 200(Success) return <see cref="GetProductDto"/></response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Response<GetProductDto>> GetProduct(
            [FromRoute] long id,
            CancellationToken cancellationToken)
        {
            var result = await this._processor.SendAsync(new GetProductQuery(id), cancellationToken);
            return this.ProduceResponse(result);
        }

        /// <summary>
        /// Insert Product
        /// </summary>
        /// <response code="200">if response code is 200(Success) return <see cref="GenericIdDto"/></response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost("")]
        [ProducesResponseType(typeof(GenericIdDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Response<GenericIdDto>> InsertProduct(
            [FromBody] InsertProductCommand request,
            CancellationToken cancellationToken)
        {
            var result = await this._processor.SendAsync(request, cancellationToken);
            return this.ProduceResponse(result);
        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <response code="200">if response code is 200(Success) return <see cref="GenericIdDto"/></response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(GenericIdDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Response<GenericIdDto>> UpdateProduct(
            [FromRoute] long id,
            [FromBody] UpdateProductCommand request,
            CancellationToken cancellationToken)
        {
            request.Id = id;
            var result = await this._processor.SendAsync(request, cancellationToken);
            return this.ProduceResponse(result);
        }
    }
}
