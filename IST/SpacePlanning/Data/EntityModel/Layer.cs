using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class Layer
    {
        public Layer()
        {
            Lock = new HashSet<Lock>();
            PhysicalElement = new HashSet<PhysicalElement>();
        }

        public Guid LayerId { get; set; }
        public Guid SceneId { get; set; }
        public Guid LayerTypeId { get; set; }
        public int? Zorder { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public LayerType LayerType { get; set; }
        public Scene Scene { get; set; }
        public ICollection<Lock> Lock { get; set; }
        public ICollection<PhysicalElement> PhysicalElement { get; set; }
    }
}
