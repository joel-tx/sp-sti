using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class LogLevel
    {
        public long LogLevelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<AuditLog> AuditLog { get; set; }
    }
}
