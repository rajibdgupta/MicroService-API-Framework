using System;
using System.Collections.Generic;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class UserSecurityQuest
    {
        public int UserSecurityQuestId { get; set; }
        public int RepId { get; set; }
        public short QuestId { get; set; }
        public string QuestAns { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual SecurityQuest Quest { get; set; }
        public virtual RepMst Rep { get; set; }
    }
}
