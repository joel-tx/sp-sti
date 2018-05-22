using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class Preference
    {
        public Preference()
        {
            PreferenceUser = new HashSet<PreferenceUser>();
        }

        public Guid PreferenceId { get; set; }
        public string Data { get; set; }

        public ICollection<PreferenceUser> PreferenceUser { get; set; }
    }
}
