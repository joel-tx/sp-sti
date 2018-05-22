using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class RolePermission
    {
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }

        public Permission Permission { get; set; }
        public Role Role { get; set; }
    }
}
