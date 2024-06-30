using Calendar.Application.Days.Queries.GetNote;
using Calendar.Application.Days.Queries.GetNotes;
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

        [HttpGet("{id}")]
        public Task<NoteDto> GetFirstNote(int id)
        {
            return Mediator.Send(new GetNoteByIdQuery() { NoteId = id });
        }


        [HttpGet()]
        public Task<IEnumerable<NoteDto>> GetAllNotes()
        {
            return Mediator.Send(new GetNotesQuery());
        }

    }
}
