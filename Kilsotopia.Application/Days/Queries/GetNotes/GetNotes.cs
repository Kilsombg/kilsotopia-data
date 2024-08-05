using AutoMapper;
using AutoMapper.QueryableExtensions;
using Kilsotopia.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kilsotopia.Application.Days.Queries.GetNotes
{
    public class GetNotesQuery : IRequest<IEnumerable<NoteDto>> { }

    public class GetNotesQueryHandler : IRequestHandler<GetNotesQuery, IEnumerable<NoteDto>>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public GetNotesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<NoteDto>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
        {
            return await context.Notes
                .ProjectTo<NoteDto>(mapper.ConfigurationProvider)
                .ToArrayAsync();
        }
    }
}
