using Calendar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Domain.Entities
{
    public class Note : BaseAuditableEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public string? Notes { get; set; }
    }
}
