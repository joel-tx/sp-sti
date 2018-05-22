using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class Plan
    {
        public Plan()
        {
            PlanUser = new HashSet<PlanUser>();
            Scene = new HashSet<Scene>();
        }

        public Guid PlanId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ModifyDate { get; set; }

        public ICollection<PlanUser> PlanUser { get; set; }
        public ICollection<Scene> Scene { get; set; }
    }
}
