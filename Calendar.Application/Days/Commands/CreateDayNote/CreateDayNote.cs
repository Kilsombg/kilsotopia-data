using Calendar.Application.Common.Interfaces;
using Calendar.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Application.Days.Commands.CreateDayNote
{
    public class CreateDayNote : IRequest<int>
    {
        public DateTime Date { get; set; }
        public string? Notes { get; set; }
    }

    public class CreateDayNoteHandler : IRequestHandler<CreateDayNote, int> {
        public IApplicationDbContext _context { get; }

        public CreateDayNoteHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateDayNote request, CancellationToken cancellationToken)
        {
            Note note = new Note()
            {
                Date = request.Date,
                Notes = request.Notes,
                Created = DateTime.UtcNow,
                CreatedBy = "Kilsom"
            };

            _context.Notes.Add(note);
            await _context.SaveChangesAsync(cancellationToken);

            return note.Id;
        }
    }
}
