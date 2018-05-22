using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class Graphic
    {
        public Graphic()
        {
            Element = new HashSet<Element>();
        }

        public Guid GraphicId { get; set; }
        public string Name { get; set; }
        public int? Height { get; set; }
        public int? Width { get; set; }
        public Guid GraphicTypeId { get; set; }
        public string Description { get; set; }

        public GraphicType GraphicType { get; set; }
        public ICollection<Element> Element { get; set; }
    }
}
