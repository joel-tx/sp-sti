using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class EntityType
    {
        public EntityType()
        {
            Entity = new HashSet<Entity>();
        }

        public Guid EntityTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Entity> Entity { get; set; }
    }
}
