using Calendar.Application.Common.Interfaces;
using Calendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Infrastructure.Data
{
    public class ApplicaationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Note> Notes { get; set; }
    }
}
