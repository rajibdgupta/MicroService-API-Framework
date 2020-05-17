using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ZydusFrontline.Entity.FamilyDetails
{
    public class PersonalDetailEntity
    {
        [Key]
        public int UniqueKey { get; set; }
        public string MemberName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string RelationWithEmp { get; set; }
        public string MaritalStatus { get; set; }
        public string NameOfNominee { get; set; }
        public string RelationOfNomineeWithEmp { get; set; }
        public string Reason { get; set; }
    }

    public class MemberEntity
    {
        public int MemberId { get; set; }
        public string MemberDesc { get; set; }
    }
}
