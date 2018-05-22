using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class Permission
    {
        public Permission()
        {
            ObjectPermission = new HashSet<ObjectPermission>();
            OperationPermission = new HashSet<OperationPermission>();
            RolePermission = new HashSet<RolePermission>();
        }

        public Guid PermissionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<ObjectPermission> ObjectPermission { get; set; }
        public ICollection<OperationPermission> OperationPermission { get; set; }
        public ICollection<RolePermission> RolePermission { get; set; }
    }
}
