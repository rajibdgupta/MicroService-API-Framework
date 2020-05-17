using System;
using System.Collections.Generic;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class Area
    {
        public Area()
        {
            Headquarter = new HashSet<Headquarter>();
            RepMst = new HashSet<RepMst>();
        }

        public int AreaId { get; set; }
        public int RegionId { get; set; }
        public string AreaCode { get; set; }
        public string AreaDesc { get; set; }
        public string ZdAreaCode { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<Headquarter> Headquarter { get; set; }
        public virtual ICollection<RepMst> RepMst { get; set; }
    }
}
