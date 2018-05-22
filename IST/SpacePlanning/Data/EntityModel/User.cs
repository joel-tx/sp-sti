using System;
using System.Collections.Generic;

namespace IST.SpacePlanning.Data.EntityModel
{
    public partial class User
    {
        public User()
        {
            ElementUser = new HashSet<ElementUser>();
            EntityUser = new HashSet<EntityUser>();
            LockUser = new HashSet<LockUser>();
            PlanUser = new HashSet<PlanUser>();
            PreferenceUser = new HashSet<PreferenceUser>();
            UserRole = new HashSet<UserRole>();
        }

        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int LockoutCount { get; set; }
        public DateTime? ActiveDate { get; set; }

        public ICollection<AuditLog> AuditLog { get; set; }
        public ICollection<ElementUser> ElementUser { get; set; }
        public ICollection<EntityUser> EntityUser { get; set; }
        public ICollection<LockUser> LockUser { get; set; }
        public ICollection<PlanUser> PlanUser { get; set; }
        public ICollection<PreferenceUser> PreferenceUser { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
    }
}
