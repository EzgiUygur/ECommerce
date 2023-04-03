using ECommerce.Api.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : Controller
    {
        protected Response<TBody> ProduceResponse<TBody>(TBody body)
        {
            return Response<TBody>.Success(body);
        }
    }
}
