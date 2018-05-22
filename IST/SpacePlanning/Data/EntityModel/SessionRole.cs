using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class SessionRole
    {
        public Guid SessionId { get; set; }
        public Guid RoleId { get; set; }

        public Role Role { get; set; }
        public Session Session { get; set; }
    }
}
