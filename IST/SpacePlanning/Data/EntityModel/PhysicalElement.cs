using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class PhysicalElement
    {
        public Guid PhysicalElementId { get; set; }
        public Guid ElementId { get; set; }
        public Guid LayerId { get; set; }
        public int Startx { get; set; }
        public int Starty { get; set; }
        public int Endx { get; set; }
        public int Endy { get; set; }
        public int? Zorder { get; set; }
        public int? Rotation { get; set; }
        public string Color { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }

        public Element Element { get; set; }
        public Layer Layer { get; set; }
    }
}
