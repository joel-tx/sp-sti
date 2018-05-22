using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class EntityName
    {
        public Guid NameId { get; set; }
        public Guid EntityId { get; set; }

        public Entity Entity { get; set; }
        public Name Name { get; set; }
    }
}
