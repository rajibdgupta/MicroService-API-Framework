using System;
using System.Collections.Generic;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class Qualification
    {
        public Qualification()
        {
            DrMstDraft = new HashSet<DrMstDraft>();
        }

        public int QualificationId { get; set; }
        public string QualiCode { get; set; }
        public string QualiDesc { get; set; }
        public int SpecId { get; set; }
        public string OldQuali { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Speciality Spec { get; set; }
        public virtual ICollection<DrMstDraft> DrMstDraft { get; set; }
    }
}
