using System;
using System.Collections.Generic;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class UserMst
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public int SbuId { get; set; }
        public int RepId { get; set; }
        public string Psw { get; set; }
        public DateTime? PswChangeDate { get; set; }
        public DateTime? LockTillDate { get; set; }
        public short? LockCounter { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Company Company { get; set; }
        public virtual RepMst Rep { get; set; }
        public virtual Sbu Sbu { get; set; }
    }
}
