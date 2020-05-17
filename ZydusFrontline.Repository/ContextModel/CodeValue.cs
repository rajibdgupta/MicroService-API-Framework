using System;
using System.Collections.Generic;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class CodeValue
    {
        public CodeValue()
        {
            DrAddrDraft = new HashSet<DrAddrDraft>();
            FamilyDetailGender = new HashSet<FamilyDetail>();
            FamilyDetailMaritalStatus = new HashSet<FamilyDetail>();
            RepMst = new HashSet<RepMst>();
        }

        public int CodeValId { get; set; }
        public string ValCode { get; set; }
        public string ValDesc { get; set; }
        public string TypeCode { get; set; }
        public int SeqNo { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<DrAddrDraft> DrAddrDraft { get; set; }
        public virtual ICollection<FamilyDetail> FamilyDetailGender { get; set; }
        public virtual ICollection<FamilyDetail> FamilyDetailMaritalStatus { get; set; }
        public virtual ICollection<RepMst> RepMst { get; set; }
    }
}
