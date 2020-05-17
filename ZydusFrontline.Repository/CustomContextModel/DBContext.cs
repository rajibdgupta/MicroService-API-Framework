using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using ZydusFrontline.Entity.FamilyDetails;

namespace ZydusFrontline.Repository.ContextModel
{
    public partial class DBContext : DbContext
    {
        public virtual DbSet<PersonalDetailEntity> PersonalDetailEntityListSP { get; set; }

    }
}
