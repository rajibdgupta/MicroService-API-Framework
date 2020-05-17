using System;
using System.Collections.Generic;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class Region
    {
        public Region()
        {
            Area = new HashSet<Area>();
            RepMst = new HashSet<RepMst>();
        }

        public int RegionId { get; set; }
        public int ZoneId { get; set; }
        public string RegionCode { get; set; }
        public string RegionDesc { get; set; }
        public string ZdRegionCode { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Zone Zone { get; set; }
        public virtual ICollection<Area> Area { get; set; }
        public virtual ICollection<RepMst> RepMst { get; set; }
    }
}
