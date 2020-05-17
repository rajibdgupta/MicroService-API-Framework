using System;
using System.Collections.Generic;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class ZrahGroupRights
    {
        public int ZrahGroupRightsId { get; set; }
        public int CompanyId { get; set; }
        public int SbuId { get; set; }
        public string GeoGroupId { get; set; }
        public string ZoneId { get; set; }
        public string RegionId { get; set; }
        public string AreaId { get; set; }
        public string HqId { get; set; }
        public string GeoGroupDesc { get; set; }
        public string RcompId { get; set; }
        public string RsbuId { get; set; }
        public string Status { get; set; }
        public string OldGeogroupId { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Company Company { get; set; }
        public virtual Sbu Sbu { get; set; }
    }
}
