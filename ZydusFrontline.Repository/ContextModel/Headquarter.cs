using System;
using System.Collections.Generic;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class Headquarter
    {
        public Headquarter()
        {
            RepMst = new HashSet<RepMst>();
        }

        public int HeadquarterId { get; set; }
        public int AreaId { get; set; }
        public string HqCode { get; set; }
        public string HqDesc { get; set; }
        public string ZdHqCode { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Area Area { get; set; }
        public virtual ICollection<RepMst> RepMst { get; set; }
    }
}
