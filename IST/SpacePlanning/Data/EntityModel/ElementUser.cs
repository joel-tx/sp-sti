using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class ElementUser
    {
        public Guid ElementId { get; set; }
        public Guid UserId { get; set; }

        public Element Element { get; set; }
        public User User { get; set; }
    }
}
