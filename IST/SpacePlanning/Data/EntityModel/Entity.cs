using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class Entity
    {
        public Entity()
        {
            EntityAddress = new HashSet<EntityAddress>();
            EntityName = new HashSet<EntityName>();
            EntityUser = new HashSet<EntityUser>();
        }

        public Guid EntityId { get; set; }
        public Guid EntityTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public EntityType EntityType { get; set; }
        public ICollection<EntityAddress> EntityAddress { get; set; }
        public ICollection<EntityName> EntityName { get; set; }
        public ICollection<EntityUser> EntityUser { get; set; }
    }
}
