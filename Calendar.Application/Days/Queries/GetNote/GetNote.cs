using AutoMapper;
using AutoMapper.QueryableExtensions;
using Calendar.Application.Common.Interfaces;
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
    public class GetNoteQuery : IRequest<NoteDto>
    {
    }

    public class GetNoteQueryHandler : IRequestHandler<GetNoteQuery, NoteDto>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public GetNoteQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<NoteDto> Handle(GetNoteQuery request, CancellationToken cancellationToken)
        {
            return await context.Notes.ProjectTo<NoteDto>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }
    }
}
