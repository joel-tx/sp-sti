using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class GraphicType
    {
        public GraphicType()
        {
            Graphic = new HashSet<Graphic>();
        }

        public Guid GraphicTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Graphic> Graphic { get; set; }
    }
}
