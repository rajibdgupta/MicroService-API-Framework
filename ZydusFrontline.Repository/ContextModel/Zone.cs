using System;
using System.Collections.Generic;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class Zone
    {
        public Zone()
        {
            Region = new HashSet<Region>();
            RepMst = new HashSet<RepMst>();
        }

        public int ZoneId { get; set; }
        public int SbuId { get; set; }
        public string ZoneCode { get; set; }
        public string ZoneDesc { get; set; }
        public string ZdZoneCode { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Sbu Sbu { get; set; }
        public virtual ICollection<Region> Region { get; set; }
        public virtual ICollection<RepMst> RepMst { get; set; }
    }
}
