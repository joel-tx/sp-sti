using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class Operation
    {
        public Operation()
        {
            OperationPermission = new HashSet<OperationPermission>();
        }

        public Guid OperationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<OperationPermission> OperationPermission { get; set; }
    }
}
