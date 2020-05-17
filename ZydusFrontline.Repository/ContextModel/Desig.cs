using System;
using System.Collections.Generic;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class Desig
    {
        public Desig()
        {
            DesigGrp = new HashSet<DesigGrp>();
            McrCategory = new HashSet<McrCategory>();
            RepMst = new HashSet<RepMst>();
        }

        public int DesigId { get; set; }
        public int SbuId { get; set; }
        public string DesigCode { get; set; }
        public string DesigDesc { get; set; }
        public string LeaveFlag { get; set; }
        public short? DesigHierarchy { get; set; }
        public string DesigCategory { get; set; }
        public string ConfirmationFlag { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Sbu Sbu { get; set; }
        public virtual ICollection<DesigGrp> DesigGrp { get; set; }
        public virtual ICollection<McrCategory> McrCategory { get; set; }
        public virtual ICollection<RepMst> RepMst { get; set; }
    }
}
