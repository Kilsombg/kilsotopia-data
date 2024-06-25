using Calendar.Application.Days.Queries.GetNote;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CalendarApi.Controllers
{
    [ApiController]
    public class NoteController : BaseController
    {
        public NoteController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public Task<NoteDto> GetFirstNote()
        {
            return Mediator.Send(new GetNoteQuery());
        }
    }
}
