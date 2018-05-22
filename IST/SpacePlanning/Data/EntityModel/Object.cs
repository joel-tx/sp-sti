using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class Object
    {
        public Object()
        {
            ObjectPermission = new HashSet<ObjectPermission>();
        }

        public Guid ObjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<ObjectPermission> ObjectPermission { get; set; }
    }
}
