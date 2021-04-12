using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Domain.Common
{
    public class AuditableEntity
    {
        public DateTime? LastEditAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public string EditedBy { get; set; }
        public string CreatedBy { get; set; }
    }
}
