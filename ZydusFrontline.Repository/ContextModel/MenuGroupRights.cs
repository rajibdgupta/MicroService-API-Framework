using System;
using System.Collections.Generic;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class MenuGroupRights
    {
        public int MenuGroupRightsId { get; set; }
        public int CompanyId { get; set; }
        public int SbuId { get; set; }
        public string MenuGroupId { get; set; }
        public int MenuId { get; set; }
        public string SfaActiveFlag { get; set; }
        public string RepDeptCode { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Company Company { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual Sbu Sbu { get; set; }
    }
}
