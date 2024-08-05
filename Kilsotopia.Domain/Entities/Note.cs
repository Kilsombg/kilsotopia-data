using Kilsotopia.Domain.Common;

namespace Kilsotopia.Domain.Entities
{
    public class Note : BaseAuditableEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public string? Notes { get; set; }
    }
}
