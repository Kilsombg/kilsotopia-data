using Kilsotopia.Application.Common.Interfaces;
using MediatR;

namespace Kilsotopia.Application.Days.Commands.UpdateDayNote
{
    public class UpdateDayNote : IRequest
    {
        public int Id { get; set; }
        public string Notes { get; set; }
    }

    public class UpdateDayNoteHandler : IRequestHandler<UpdateDayNote>
    {
        private readonly IApplicationDbContext _context;

        public UpdateDayNoteHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateDayNote request, CancellationToken cancellationToken)
        {
            var entity = await _context.Notes.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                return;
            }

            entity.Notes = request.Notes;

            entity.LastModified = DateTime.UtcNow;
            entity.LastModifiedBy = "Kilsom";

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
