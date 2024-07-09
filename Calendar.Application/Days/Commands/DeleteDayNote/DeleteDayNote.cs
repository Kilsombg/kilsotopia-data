using Calendar.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Application.Days.Commands.DeleteDayNote
{
    public class DeleteDayNote : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteDayNoteHandler : IRequestHandler<DeleteDayNote>
    {
        private readonly IApplicationDbContext _context;

        public DeleteDayNoteHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Handle(DeleteDayNote request, CancellationToken cancellationToken)
        {
            var entity = await _context.Notes.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                return;
            }

            _context.Notes.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
