using AutoMapper;
using Calendar.Domain.Entities;
using System;

namespace Calendar.Application.Days.Queries.GetNote
{
    public class NoteDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Note, NoteDto>();
            }
        }
    }
}