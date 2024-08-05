using Kilsotopia.Application.Common.Interfaces;
using Kilsotopia.Domain.Entities;
using MediatR;

namespace Kilsotopia.Application.Days.Commands.CreateDayNote
{
    public class CreateDayNote : IRequest<int>
    {
        public DateTime Date { get; set; }
        public string? Notes { get; set; }
    }

    public class CreateDayNoteHandler : IRequestHandler<CreateDayNote, int>
    {
        public IApplicationDbContext _context { get; }

        public CreateDayNoteHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateDayNote request, CancellationToken cancellationToken)
        {
            Note note = new Note()
            {
                Date = request.Date.ToLocalTime(),
                Notes = request.Notes,
                Created = DateTime.Now,
                CreatedBy = "Kilsom"
            };

            _context.Notes.Add(note);
            await _context.SaveChangesAsync(cancellationToken);

            return note.Id;
        }
    }
}
