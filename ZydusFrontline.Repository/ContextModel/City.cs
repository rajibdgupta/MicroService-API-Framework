using System;
using System.Collections.Generic;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class City
    {
        public City()
        {
            DrAddrDraft = new HashSet<DrAddrDraft>();
            DrMstDraft = new HashSet<DrMstDraft>();
            RepMst = new HashSet<RepMst>();
        }

        public int CityId { get; set; }
        public int StateId { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public int SerNoDr { get; set; }
        public int SerNoChemist { get; set; }
        public string FinalCityCode { get; set; }
        public string FinDelFlag { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual State State { get; set; }
        public virtual ICollection<DrAddrDraft> DrAddrDraft { get; set; }
        public virtual ICollection<DrMstDraft> DrMstDraft { get; set; }
        public virtual ICollection<RepMst> RepMst { get; set; }
    }
}
