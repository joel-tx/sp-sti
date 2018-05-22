using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class Element
    {
        public Element()
        {
            ElementUser = new HashSet<ElementUser>();
            Lock = new HashSet<Lock>();
            PhysicalElement = new HashSet<PhysicalElement>();
        }

        public Guid ElementId { get; set; }
        public Guid GraphicId { get; set; }
        public Guid ElementTypeId { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }

        public ElementType ElementType { get; set; }
        public Graphic Graphic { get; set; }
        public ICollection<ElementUser> ElementUser { get; set; }
        public ICollection<Lock> Lock { get; set; }
        public ICollection<PhysicalElement> PhysicalElement { get; set; }
    }
}
