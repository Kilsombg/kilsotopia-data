using AutoMapper;
using AutoMapper.QueryableExtensions;
using Calendar.Application.Common.Interfaces;
using Calendar.Application.Days.Queries.GetNotes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calendar.Application.Days.Queries.GetNote
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
