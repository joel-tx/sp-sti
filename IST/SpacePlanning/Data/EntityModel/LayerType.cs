using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class LayerType
    {
        public LayerType()
        {
            Layer = new HashSet<Layer>();
        }

        public Guid LayerTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Layer> Layer { get; set; }
    }
}
