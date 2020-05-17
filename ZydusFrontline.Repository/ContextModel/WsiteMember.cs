using System;
using System.Collections.Generic;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class WsiteMember
    {
        public WsiteMember()
        {
            WsiteFamilyDetailMember = new HashSet<WsiteFamilyDetail>();
            WsiteFamilyDetailNomineeRelation = new HashSet<WsiteFamilyDetail>();
        }

        public int MemberId { get; set; }
        public string MemberCode { get; set; }
        public string MemberDesc { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<WsiteFamilyDetail> WsiteFamilyDetailMember { get; set; }
        public virtual ICollection<WsiteFamilyDetail> WsiteFamilyDetailNomineeRelation { get; set; }
    }
}
