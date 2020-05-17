using System;
using System.Collections.Generic;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class TownType
    {
        public TownType()
        {
            RepMst = new HashSet<RepMst>();
        }

        public int TownTypeId { get; set; }
        public int CompanyId { get; set; }
        public string TownTypeCode { get; set; }
        public string TownTypeDesc { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<RepMst> RepMst { get; set; }
    }
}
