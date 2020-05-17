using System;
using System.Collections.Generic;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class Speciality
    {
        public Speciality()
        {
            DrMstDraftOriginalSpec = new HashSet<DrMstDraft>();
            DrMstDraftSpec = new HashSet<DrMstDraft>();
            Qualification = new HashSet<Qualification>();
        }

        public int SpecialityId { get; set; }
        public int CompanyId { get; set; }
        public string SpecCode { get; set; }
        public string SpecDesc { get; set; }
        public string SpecStatus { get; set; }
        public string DedupliStatus { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<DrMstDraft> DrMstDraftOriginalSpec { get; set; }
        public virtual ICollection<DrMstDraft> DrMstDraftSpec { get; set; }
        public virtual ICollection<Qualification> Qualification { get; set; }
    }
}
