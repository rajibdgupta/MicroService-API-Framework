using System;
using System.Collections.Generic;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class UserHistory
    {
        public int UserHistoryId { get; set; }
        public int CompanyId { get; set; }
        public int SbuId { get; set; }
        public int RepId { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }
        public string HostIpName { get; set; }
        public short? TotDcr { get; set; }
        public short? SeqNo { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Company Company { get; set; }
        public virtual RepMst Rep { get; set; }
        public virtual Sbu Sbu { get; set; }
    }
}
