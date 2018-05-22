using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class LockUser
    {
        public Guid UserId { get; set; }
        public Guid LockId { get; set; }

        public Lock Lock { get; set; }
        public User User { get; set; }
    }
}
