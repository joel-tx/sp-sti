using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class EntityUser
    {
        public Guid EntityId { get; set; }
        public Guid UserId { get; set; }

        public Entity Entity { get; set; }
        public User User { get; set; }
    }
}
