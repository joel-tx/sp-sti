using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class Lock
    {
        public Lock()
        {
            LockUser = new HashSet<LockUser>();
        }

        public Guid LockId { get; set; }
        public Guid SceneId { get; set; }
        public Guid LayerId { get; set; }
        public Guid ElementId { get; set; }

        public Element Element { get; set; }
        public Layer Layer { get; set; }
        public Scene Scene { get; set; }
        public ICollection<LockUser> LockUser { get; set; }
    }
}
