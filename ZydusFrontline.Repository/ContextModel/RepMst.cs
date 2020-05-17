using System;
using System.Collections.Generic;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class RepMst
    {
        public RepMst()
        {
            DrAddrDraftApprovalLevel1By = new HashSet<DrAddrDraft>();
            DrAddrDraftApprovalLevel2By = new HashSet<DrAddrDraft>();
            DrAddrDraftApprovalLevel3By = new HashSet<DrAddrDraft>();
            DrAddrDraftApprovedBy = new HashSet<DrAddrDraft>();
            DrAddrDraftHoApprovalBy = new HashSet<DrAddrDraft>();
            DrMstDraftApprovalLevel1By = new HashSet<DrMstDraft>();
            DrMstDraftApprovalLevel2By = new HashSet<DrMstDraft>();
            DrMstDraftApprovalLevel3By = new HashSet<DrMstDraft>();
            DrMstDraftApprovedBy = new HashSet<DrMstDraft>();
            DrMstDraftHoApprovalBy = new HashSet<DrMstDraft>();
            DrMstDraftRep = new HashSet<DrMstDraft>();
            FamilyDetail = new HashSet<FamilyDetail>();
            UserHistory = new HashSet<UserHistory>();
            UserMenuGroupRights = new HashSet<UserMenuGroupRights>();
            UserMst = new HashSet<UserMst>();
            UserSecurityQuest = new HashSet<UserSecurityQuest>();
            UserZrahGroup = new HashSet<UserZrahGroup>();
        }

        public int RepId { get; set; }
        public int SbuId { get; set; }
        public string RepCode { get; set; }
        public string CnsCode { get; set; }
        public int ZoneId { get; set; }
        public int RegionId { get; set; }
        public int? AreaId { get; set; }
        public int? HqId { get; set; }
        public string Category { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string Add3 { get; set; }
        public string Area { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string PinCode { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Smsmail { get; set; }
        public string Push { get; set; }
        public string Pull { get; set; }
        public int? DesigId { get; set; }
        public string SalaryHold { get; set; }
        public string Status { get; set; }
        public DateTime JoinedDate { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public DateTime? ResignDate { get; set; }
        public decimal AlwPerKm { get; set; }
        public int? TownTypeId { get; set; }
        public string CcmailFlag { get; set; }
        public string SampleHold { get; set; }
        public short? HoldMonth { get; set; }
        public short? HoldYear { get; set; }
        public string PartyCode { get; set; }
        public string OrgCompCode { get; set; }
        public string SmsPushGroup { get; set; }
        public string SmsTotalFlag { get; set; }
        public string SmsMktFinAmt { get; set; }
        public string Locked { get; set; }
        public DateTime? UnlockedTillDate { get; set; }
        public short? LockCounter { get; set; }
        public string AbscondingFlag { get; set; }
        public DateTime? AbscondingDate { get; set; }
        public string ResignFlag { get; set; }
        public int? EmployeeTypeId { get; set; }
        public string LaptopSrNo { get; set; }
        public string HostIpName { get; set; }
        public string PreDesigCode { get; set; }
        public DateTime? PromotionDate { get; set; }
        public DateTime? DemotionDate { get; set; }
        public string ConsiderationFlag { get; set; }
        public int? McrCategoryId { get; set; }
        public string HoDesigGrpCode { get; set; }
        public DateTime? DcrStartDate { get; set; }
        public string TrinityDesignationCode { get; set; }
        public string ResignFlagId { get; set; }
        public DateTime? ResignFlagDate { get; set; }
        public string HoldFlag { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Area AreaNavigation { get; set; }
        public virtual City City { get; set; }
        public virtual Desig Desig { get; set; }
        public virtual CodeValue EmployeeType { get; set; }
        public virtual Headquarter Hq { get; set; }
        public virtual McrCategory McrCategory { get; set; }
        public virtual Region Region { get; set; }
        public virtual Sbu Sbu { get; set; }
        public virtual State State { get; set; }
        public virtual TownType TownType { get; set; }
        public virtual Zone Zone { get; set; }
        public virtual ICollection<DrAddrDraft> DrAddrDraftApprovalLevel1By { get; set; }
        public virtual ICollection<DrAddrDraft> DrAddrDraftApprovalLevel2By { get; set; }
        public virtual ICollection<DrAddrDraft> DrAddrDraftApprovalLevel3By { get; set; }
        public virtual ICollection<DrAddrDraft> DrAddrDraftApprovedBy { get; set; }
        public virtual ICollection<DrAddrDraft> DrAddrDraftHoApprovalBy { get; set; }
        public virtual ICollection<DrMstDraft> DrMstDraftApprovalLevel1By { get; set; }
        public virtual ICollection<DrMstDraft> DrMstDraftApprovalLevel2By { get; set; }
        public virtual ICollection<DrMstDraft> DrMstDraftApprovalLevel3By { get; set; }
        public virtual ICollection<DrMstDraft> DrMstDraftApprovedBy { get; set; }
        public virtual ICollection<DrMstDraft> DrMstDraftHoApprovalBy { get; set; }
        public virtual ICollection<DrMstDraft> DrMstDraftRep { get; set; }
        public virtual ICollection<FamilyDetail> FamilyDetail { get; set; }
        public virtual ICollection<UserHistory> UserHistory { get; set; }
        public virtual ICollection<UserMenuGroupRights> UserMenuGroupRights { get; set; }
        public virtual ICollection<UserMst> UserMst { get; set; }
        public virtual ICollection<UserSecurityQuest> UserSecurityQuest { get; set; }
        public virtual ICollection<UserZrahGroup> UserZrahGroup { get; set; }
    }
}
