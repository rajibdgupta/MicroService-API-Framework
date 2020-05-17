using System;
using System.Collections.Generic;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class Menu
    {
        public Menu()
        {
            InverseParentMenu = new HashSet<Menu>();
            MenuGroupRights = new HashSet<MenuGroupRights>();
        }

        public int MenuId { get; set; }
        public string MenuCode { get; set; }
        public string Status { get; set; }
        public string MenuDesc { get; set; }
        public int? ParentMenuId { get; set; }
        public string PageReference { get; set; }
        public string IconReference { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Menu ParentMenu { get; set; }
        public virtual ICollection<Menu> InverseParentMenu { get; set; }
        public virtual ICollection<MenuGroupRights> MenuGroupRights { get; set; }
    }
}
