using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class UserRole
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public Role Role { get; set; }
        public User User { get; set; }
    }
}
