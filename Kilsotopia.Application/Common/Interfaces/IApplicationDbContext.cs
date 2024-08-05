using Kilsotopia.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kilsotopia.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Note> Notes { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
