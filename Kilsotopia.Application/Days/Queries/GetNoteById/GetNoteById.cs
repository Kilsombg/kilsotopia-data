using AutoMapper;
using AutoMapper.QueryableExtensions;
using Kilsotopia.Application.Common.Interfaces;
using Kilsotopia.Application.Days.Queries.GetNotes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kilsotopia.Application.Days.Queries.GetNoteById
{
    public class GetNoteByIdQuery : IRequest<NoteDto>
    {
        public int NoteId { get; set; }
    }

    public class GetNoteByIdQueryHandler : IRequestHandler<GetNoteByIdQuery, NoteDto>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public GetNoteByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<NoteDto> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
        {
            return await context.Notes
                .Where(x => x.Id == request.NoteId)
                .ProjectTo<NoteDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }
    }
}
