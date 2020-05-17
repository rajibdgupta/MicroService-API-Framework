using System;
using System.Collections.Generic;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class Company
    {
        public Company()
        {
            DrMstDraft = new HashSet<DrMstDraft>();
            MenuGroupRights = new HashSet<MenuGroupRights>();
            Sbu = new HashSet<Sbu>();
            Speciality = new HashSet<Speciality>();
            State = new HashSet<State>();
            TownType = new HashSet<TownType>();
            UserHistory = new HashSet<UserHistory>();
            UserMenuGroupRights = new HashSet<UserMenuGroupRights>();
            UserMst = new HashSet<UserMst>();
            UserZrahGroup = new HashSet<UserZrahGroup>();
            ZrahGroupRights = new HashSet<ZrahGroupRights>();
        }

        public int CompanyId { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string OldCompCode { get; set; }
        public string UndupliFlag { get; set; }
        public string Place { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<DrMstDraft> DrMstDraft { get; set; }
        public virtual ICollection<MenuGroupRights> MenuGroupRights { get; set; }
        public virtual ICollection<Sbu> Sbu { get; set; }
        public virtual ICollection<Speciality> Speciality { get; set; }
        public virtual ICollection<State> State { get; set; }
        public virtual ICollection<TownType> TownType { get; set; }
        public virtual ICollection<UserHistory> UserHistory { get; set; }
        public virtual ICollection<UserMenuGroupRights> UserMenuGroupRights { get; set; }
        public virtual ICollection<UserMst> UserMst { get; set; }
        public virtual ICollection<UserZrahGroup> UserZrahGroup { get; set; }
        public virtual ICollection<ZrahGroupRights> ZrahGroupRights { get; set; }
    }
}
