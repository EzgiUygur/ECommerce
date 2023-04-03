using ECommerce.Api.Messaging;
using ECommerce.Application.Responses;
using ECommerce.Application.Users.CreateUser;
using ECommerce.Application.Users.DeleteUser;
using ECommerce.Application.Users.DeleteUserBasket;
using ECommerce.Application.Users.GetUser;
using ECommerce.Application.Users.GetUserBaskets;
using ECommerce.Application.Users.GetUserCount;
using ECommerce.Application.Users.GetUsers;
using ECommerce.Application.Users.InsertUserBasket;
using ECommerce.Application.Users.UpdateUser;
using ECommerce.Application.Users.UpdateUserDetail;
using ECommerce.Core.MessagingAdapter;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    public class UsersController : BaseController
    {
        private readonly ICQRSProcessor _processor;

        public UsersController(ICQRSProcessor processor)
        {
            this._processor = processor;
        }


        /// <summary>
        /// Get User Count
        /// </summary>
        /// <response code="500">Internal Server Error</response>
        [HttpHead("")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserCount(
            [FromQuery] GetUserCountQuery request,
            CancellationToken cancellationToken)
        {
            var result = await this._processor.SendAsync(request, cancellationToken);

            _ = this.Response.Headers.TryAdd("X-Total-Records", result.ToString());

            return this.Ok();
        }

        /// <summary>
        /// Create User
        /// </summary>
        /// <response code="200">if response code is 200(Success) return <see cref="GenericIdDto"/></response>
        /// <response code="409">Conflict</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost("")]
        [ProducesResponseType(typeof(GenericIdDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Response<GenericIdDto>> CreateUser(
            [FromBody] CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            var result = await this._processor.SendAsync(request, cancellationToken);
            return this.ProduceResponse(result);
        }

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <response code="200">if response code is 200(Success) return <see cref="GetUserDto"/></response>
        /// <response code="409">Conflict</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("")]
        [ProducesResponseType(typeof(GetUserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Response<List<GetUserDto>>> GetUsers(
            CancellationToken cancellationToken)
        {
            var result = await this._processor.SendAsync(new GetUsersQuery(), cancellationToken);
            return this.ProduceResponse(result);
        }

        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <response code="200">if response code is 200(Success) return <see cref="GetUserDto"/></response>
        /// <response code="409">Conflict</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetUserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Response<GetUserDto>> GetUser(
            [FromRoute] long id,
            CancellationToken cancellationToken)
        {
            var result = await this._processor.SendAsync(new GetUserQuery(id), cancellationToken);
            return this.ProduceResponse(result);
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <response code="200">if response code is 200(Success) return <see cref="GenericIdDto"/></response>
        /// <response code="409">Conflict</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(GenericIdDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Response<GenericIdDto>> UpdateUser(
            [FromRoute] long id,
            [FromBody] UpdateUserCommand request,
            CancellationToken cancellationToken)
        {
            request.Id = id;
            var result = await this._processor.SendAsync(request, cancellationToken);
            return this.ProduceResponse(result);
        }
        ///<summary>
        ///Delete User
        ///</summary>
        /// <response code="200">if response code is 200(Success) return <see cref="GenericIdDto"/></response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(GenericIdDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Response<GenericIdDto>> DeleteUser(
             [FromRoute] long id,
             CancellationToken cancellationToken)
        {
            var result = await this._processor.SendAsync(new DeleteUserCommand(id), cancellationToken);
            return this.ProduceResponse(result);
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <response code="200">if response code is 200(Success) return <see cref="GenericIdDto"/></response>
        /// <response code="409">Conflict</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut("{id}/detail")]
        [ProducesResponseType(typeof(GenericIdDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Response<GenericIdDto>> UpdateUserDetail(
            [FromRoute] long id,
            [FromBody] UpdateUserDetailCommand request,
            CancellationToken cancellationToken)
        {
            request.UserId = id;
            var result = await this._processor.SendAsync(request, cancellationToken);
            return this.ProduceResponse(result);
        }

        /// <summary>
        /// Get User Baskets
        /// </summary>
        /// <response code="200">if response code is 200(Success) return <see cref="GetUserBasketDto"/></response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("{id}/baskets")]
        [ProducesResponseType(typeof(List<GetUserBasketDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Response<List<GetUserBasketDto>>> GetUserBaskets(
            [FromRoute] long id,
            CancellationToken cancellationToken)
        {
            var result = await this._processor.SendAsync(new GetUserBasketsQuery(id), cancellationToken);
            return this.ProduceResponse(result);
        }

        /// <summary>
        /// Insert OrderLine to User Basket
        /// </summary>
        /// <response code="200">if response code is 200(Success) return <see cref="GenericIdDto"/></response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost("{id}/basket")]
        [ProducesResponseType(typeof(GenericIdDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Response<GenericIdDto>> InsertUserBasket(
            [FromRoute] long id,
            [FromBody] InsertUserBasketCommand request,
            CancellationToken cancellationToken)
        {
            request.UserId = id;
            var result = await this._processor.SendAsync(request, cancellationToken);
            return this.ProduceResponse(result);
        }

        /// <summary>
        /// Insert OrderLine to User Basket
        /// </summary>
        /// <response code="200">if response code is 200(Success) return <see cref="GenericIdDto"/></response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpDelete("{id}/basket")]
        [ProducesResponseType(typeof(GenericIdDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<Response<GenericIdDto>> DeleteUserBasket(
            [FromRoute] long id,
            CancellationToken cancellationToken)
        {
            var result = await this._processor.SendAsync(new DeleteUserBasketCommand(id), cancellationToken);
            return this.ProduceResponse(result);
        }
    }
}
