using System;
using System.Collections.Generic;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class McrCategory
    {
        public McrCategory()
        {
            RepMst = new HashSet<RepMst>();
        }

        public int McrCategoryId { get; set; }
        public int DesigId { get; set; }
        public string McrCategory1 { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Desig Desig { get; set; }
        public virtual ICollection<RepMst> RepMst { get; set; }
    }
}
