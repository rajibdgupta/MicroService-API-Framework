using System;
using System.Collections.Generic;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class Member
    {
        public Member()
        {
            FamilyDetailMember = new HashSet<FamilyDetail>();
            FamilyDetailNomineeRelation = new HashSet<FamilyDetail>();
        }

        public int MemberId { get; set; }
        public string MemberCode { get; set; }
        public string MemberDesc { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<FamilyDetail> FamilyDetailMember { get; set; }
        public virtual ICollection<FamilyDetail> FamilyDetailNomineeRelation { get; set; }
    }
}
