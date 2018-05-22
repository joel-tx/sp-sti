using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class EntityAddress
    {
        public Guid AddressId { get; set; }
        public Guid EntityId { get; set; }

        public Address Address { get; set; }
        public Entity Entity { get; set; }
    }
}
