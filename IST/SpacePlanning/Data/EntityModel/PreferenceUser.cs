using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class PreferenceUser
    {
        public Guid UserId { get; set; }
        public Guid PreferenceId { get; set; }

        public Preference Preference { get; set; }
        public User User { get; set; }
    }
}
