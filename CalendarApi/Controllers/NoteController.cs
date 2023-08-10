using Calendar.Application.Days.Queries.GetNote;
using Microsoft.AspNetCore.Mvc;

namespace CalendarApi.Controllers
{
    public class NoteController : BaseController
    {
        public Task<NoteDto> GetFirstNote(GetNoteQuery query)
        {
            return Mediator.Send(query);
        }
    }
}
