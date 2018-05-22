using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class Role
    {
        public Role()
        {
            RolePermission = new HashSet<RolePermission>();
            SessionRole = new HashSet<SessionRole>();
            UserRole = new HashSet<UserRole>();
        }

        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<RolePermission> RolePermission { get; set; }
        public ICollection<SessionRole> SessionRole { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
    }
}
