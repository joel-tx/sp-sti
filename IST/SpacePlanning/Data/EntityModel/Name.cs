using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class Name
    {
        public Name()
        {
            EntityName = new HashSet<EntityName>();
        }

        public Guid NameId { get; set; }
        public string First { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }

        public ICollection<EntityName> EntityName { get; set; }
    }
}
