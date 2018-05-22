using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class SessionLog
    {
        public Guid SessionLogId { get; set; }
        public Guid SessionId { get; set; }
        public string Entry { get; set; }
        public Guid LevelId { get; set; }
        public DateTime Timestamp { get; set; }

        public Session Session { get; set; }
    }
}
