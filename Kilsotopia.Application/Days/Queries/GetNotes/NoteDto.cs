using AutoMapper;
using Kilsotopia.Domain.Entities;

namespace Kilsotopia.Application.Days.Queries.GetNotes
{
    public class NoteDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string? Notes { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Note, NoteDto>();
            }
        }
    }
}