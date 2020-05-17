using System;
using System.Collections.Generic;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class DesigGrp
    {
        public int DesigGrpId { get; set; }
        public int DesigId { get; set; }
        public string GroupCode { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Desig Desig { get; set; }
    }
}
