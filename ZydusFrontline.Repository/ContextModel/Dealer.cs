using System;
using System.Collections.Generic;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class Dealer
    {
        public int Id { get; set; }
        public string DealerCode { get; set; }
        public string DealerName { get; set; }
        public string DealerSalesContact { get; set; }
        public string DealerSalMobile { get; set; }
        public string DealerSalName { get; set; }
        public string DealerServiceContact { get; set; }
        public string DealerSrvMobile { get; set; }
        public string DealerSrvName { get; set; }
        public string DealerType { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string LastModifiedDate { get; set; }
        public string Lattitude { get; set; }
        public string Locality { get; set; }
        public string LocationAddress { get; set; }
        public string LocationCategory { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public double? LocationPinCode { get; set; }
        public string Longitude { get; set; }
        public string ParentGroup { get; set; }
    }
}
