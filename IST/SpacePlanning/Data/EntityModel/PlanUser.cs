using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class PlanUser
    {
        public Guid PlanId { get; set; }
        public Guid UserId { get; set; }

        public Plan Plan { get; set; }
        public User User { get; set; }
    }
}
