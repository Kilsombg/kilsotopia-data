using Calendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calendar.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Note> Notes { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
