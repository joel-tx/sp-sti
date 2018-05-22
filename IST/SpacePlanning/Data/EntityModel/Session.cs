using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class Session
    {
        public Session()
        {
            SessionLog = new HashSet<SessionLog>();
            SessionRole = new HashSet<SessionRole>();
        }

        public Guid SessionId { get; set; }
        public string Value { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UserId { get; set; }

        public ICollection<SessionLog> SessionLog { get; set; }
        public ICollection<SessionRole> SessionRole { get; set; }
    }
}
