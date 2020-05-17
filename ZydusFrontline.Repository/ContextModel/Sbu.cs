using System;
using System.Collections.Generic;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class Sbu
    {
        public Sbu()
        {
            Desig = new HashSet<Desig>();
            MenuGroupRights = new HashSet<MenuGroupRights>();
            RepMst = new HashSet<RepMst>();
            UserHistory = new HashSet<UserHistory>();
            UserMenuGroupRights = new HashSet<UserMenuGroupRights>();
            UserMst = new HashSet<UserMst>();
            UserZrahGroup = new HashSet<UserZrahGroup>();
            Zone = new HashSet<Zone>();
            ZrahGroupRights = new HashSet<ZrahGroupRights>();
        }

        public int SbuId { get; set; }
        public int CompanyId { get; set; }
        public string SbuCode { get; set; }
        public string SbuName { get; set; }
        public string RepDeptCode { get; set; }
        public string ExpenseDeptCode { get; set; }
        public string ShortName { get; set; }
        public short? DisplayOrder { get; set; }
        public string OldSbuCode { get; set; }
        public string LeaveProcessFlag { get; set; }
        public string RspFlag { get; set; }
        public string SapDept { get; set; }
        public string Samg2Comp { get; set; }
        public short? PeriodDay { get; set; }
        public string SecSalesFlag { get; set; }
        public long? CostCenter { get; set; }
        public long? FundCenter { get; set; }
        public string SfaActiveFlag { get; set; }
        public string SalesCompanyCode { get; set; }
        public string TrinityActiveFlag { get; set; }
        public string ZydusCompany { get; set; }
        public string Isexpenselive { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Desig> Desig { get; set; }
        public virtual ICollection<MenuGroupRights> MenuGroupRights { get; set; }
        public virtual ICollection<RepMst> RepMst { get; set; }
        public virtual ICollection<UserHistory> UserHistory { get; set; }
        public virtual ICollection<UserMenuGroupRights> UserMenuGroupRights { get; set; }
        public virtual ICollection<UserMst> UserMst { get; set; }
        public virtual ICollection<UserZrahGroup> UserZrahGroup { get; set; }
        public virtual ICollection<Zone> Zone { get; set; }
        public virtual ICollection<ZrahGroupRights> ZrahGroupRights { get; set; }
    }
}
