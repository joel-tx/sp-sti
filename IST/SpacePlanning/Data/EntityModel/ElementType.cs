using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class ElementType
    {
        public ElementType()
        {
            Element = new HashSet<Element>();
        }

        public Guid ElementTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Element> Element { get; set; }
    }
}
