using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class ObjectPermission
    {
        public Guid ObjectId { get; set; }
        public Guid PermissionId { get; set; }

        public Object Object { get; set; }
        public Permission Permission { get; set; }
    }
}
