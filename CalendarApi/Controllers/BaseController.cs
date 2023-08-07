using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CalendarApi.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator { get; set; }

        public IMediator Mediator => _mediator;
    }
}
