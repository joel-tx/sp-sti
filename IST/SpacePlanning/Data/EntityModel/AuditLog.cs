using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class AuditLog
    {
        public Guid AuditLogId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Entry { get; set; }
        public long LevelId { get; set; }
        public Guid UserId { get; set; }
        public LogLevel Level { get; set; }
        public User User { get; set; }
    }
}
