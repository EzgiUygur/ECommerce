using ECommerce.Api.Messaging;
using ECommerce.Application.Comments.GetComment;
using ECommerce.Application.Comments.GetCommentCount;
using ECommerce.Application.Comments.GetComments;
using ECommerce.Application.Comments.InsertComment;
using ECommerce.Application.Comments.UpdateComment;
using ECommerce.Application.Responses;
using ECommerce.Core.MessagingAdapter;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    public class CommentsController : BaseController
    {
        private readonly ICQRSProcessor _processor;

        public CommentsController(ICQRSProcessor processor)
        {
            this._processor = processor;
        }

        /// <summary>
        /// Get Comment Count
        /// </summary>
        /// <response code="500">Internal Server Error</response>
        [HttpHead("")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCommentCount(
            [FromQuery] GetCommentCountQuery request,
            CancellationToken cancellationToken)
        {
            var result = await this._processor.SendAsync(request, cancellationToken);

            _ = this.Response.Headers.TryAdd("X-Total-Records", result.ToString());

            return this.Ok();
        }

        /// <summary>
        /// Get All Comments
        /// </summary>
        /// <response code="200">if response code is 200(Success) return <see cref="GetCommentDto"/></response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("")]
        [ProducesResponseType(typeof(List<GetCommentDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Response<List<GetCommentDto>>> GetComments(
            [FromQuery] GetCommentsQuery request,
            CancellationToken cancellationToken)
        {
            var result = await this._processor.SendAsync(request, cancellationToken);
            return this.ProduceResponse(result);
        }

        /// <summary>
        /// Get Comment By Id
        /// </summary>
        /// <response code="200">if response code is 200(Success) return <see cref="GetCommentDto"/></response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetCommentDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Response<GetCommentDto>> GetComment(
            [FromRoute] long id,
            CancellationToken cancellationToken)
        {
            var result = await this._processor.SendAsync(new GetCommentQuery(id), cancellationToken);
            return this.ProduceResponse(result);
        }

        /// <summary>
        /// Insert Comment
        /// </summary>
        /// <response code="200">if response code is 200(Success) return <see cref="GenericIdDto"/></response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost("")]
        [ProducesResponseType(typeof(GenericIdDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Response<GenericIdDto>> InsertComment(
            [FromBody] InsertCommentCommand command,
            CancellationToken cancellationToken)
        {
            var result = await this._processor.SendAsync(command, cancellationToken);
            return this.ProduceResponse(result);
        }

        /// <summary>
        /// Update Comment
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
        public async Task<Response<GenericIdDto>> UpdateComment(
            [FromRoute] long id,
            [FromBody] UpdateCommentCommand command,
            CancellationToken cancellationToken)
        {
            command.Id = id;
            var result = await this._processor.SendAsync(command, cancellationToken);
            return this.ProduceResponse(result);
        }
    }
}
