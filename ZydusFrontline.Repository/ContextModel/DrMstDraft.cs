﻿using System;
using System.Collections.Generic;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class DrMstDraft
    {
        public DrMstDraft()
        {
            DrAddrDraft = new HashSet<DrAddrDraft>();
        }

        public int DrMstDraftId { get; set; }
        public int CompanyId { get; set; }
        public string DrCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int QualificationId { get; set; }
        public int SpecId { get; set; }
        public string ClinicName { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string Add3 { get; set; }
        public string Area { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string PinCode { get; set; }
        public string PhoneC { get; set; }
        public string PhoneR { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? AnnDate { get; set; }
        public string RegisterCode { get; set; }
        public string Day { get; set; }
        public decimal? FromTime { get; set; }
        public decimal? ToTime { get; set; }
        public string ApprovalFlag { get; set; }
        public int? ApprovedById { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string Remark { get; set; }
        public string FinalDrCode { get; set; }
        public string CardQuali { get; set; }
        public int? RepId { get; set; }
        public short? McrNo { get; set; }
        public int? OriginalSpecId { get; set; }
        public string OriginalDrCode { get; set; }
        public string EntryCategory { get; set; }
        public int SeqNo { get; set; }
        public string ImageUrl { get; set; }
        public string ApprovalLevel1 { get; set; }
        public int? ApprovalLevel1ById { get; set; }
        public DateTime? ApprovalLevel1Date { get; set; }
        public int? ApprovalLevel1Mcrno { get; set; }
        public string ApprovalLevel1Remark { get; set; }
        public string ApprovalLevel2 { get; set; }
        public int? ApprovalLevel2ById { get; set; }
        public DateTime? ApprovalLevel2Date { get; set; }
        public int? ApprovalLevel2Mcrno { get; set; }
        public string ApprovalLevel2Remark { get; set; }
        public string ApprovalLevel3 { get; set; }
        public int? ApprovalLevel3ById { get; set; }
        public DateTime? ApprovalLevel3Date { get; set; }
        public int? ApprovalLevel3Mcrno { get; set; }
        public string ApprovalLevel3Remark { get; set; }
        public string HoApproval { get; set; }
        public int? HoApprovalById { get; set; }
        public DateTime? HoApprovalDate { get; set; }
        public string HoApprovalRemark { get; set; }
        public string ApproveOnlyAddr { get; set; }
        public string OnlyAddrDrCode { get; set; }
        public string ApprovalRemark { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual RepMst ApprovalLevel1By { get; set; }
        public virtual RepMst ApprovalLevel2By { get; set; }
        public virtual RepMst ApprovalLevel3By { get; set; }
        public virtual RepMst ApprovedBy { get; set; }
        public virtual City City { get; set; }
        public virtual Company Company { get; set; }
        public virtual RepMst HoApprovalBy { get; set; }
        public virtual Speciality OriginalSpec { get; set; }
        public virtual Qualification Qualification { get; set; }
        public virtual RepMst Rep { get; set; }
        public virtual Speciality Spec { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<DrAddrDraft> DrAddrDraft { get; set; }
    }
}
