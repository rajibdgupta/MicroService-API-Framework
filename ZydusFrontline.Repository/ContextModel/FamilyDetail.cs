using System;
using System.Collections.Generic;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class FamilyDetail
    {
        public int FamilyDetailId { get; set; }
        public int RepId { get; set; }
        public int MemberId { get; set; }
        public int SerialNo { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? GenderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? LsmwDate { get; set; }
        public int? MaritalStatusId { get; set; }
        public string NomineeName { get; set; }
        public int? NomineeRelationId { get; set; }
        public string Reason { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual CodeValue Gender { get; set; }
        public virtual CodeValue MaritalStatus { get; set; }
        public virtual Member Member { get; set; }
        public virtual Member NomineeRelation { get; set; }
        public virtual RepMst Rep { get; set; }
    }
}
