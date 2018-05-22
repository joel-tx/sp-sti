using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class OperationPermission
    {
        public Guid OperationId { get; set; }
        public Guid PermissionId { get; set; }

        public Operation Operation { get; set; }
        public Permission Permission { get; set; }
    }
}
