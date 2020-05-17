using System;
using System.Collections.Generic;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class SecurityQuest
    {
        public SecurityQuest()
        {
            UserSecurityQuest = new HashSet<UserSecurityQuest>();
        }

        public short QuestId { get; set; }
        public string QuestLine { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<UserSecurityQuest> UserSecurityQuest { get; set; }
    }
}
