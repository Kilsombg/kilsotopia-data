﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CalendarApi.Controllers
{
    [Route("/api/[controller]")]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator { get; set; }

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IMediator Mediator => _mediator;
    }
}
