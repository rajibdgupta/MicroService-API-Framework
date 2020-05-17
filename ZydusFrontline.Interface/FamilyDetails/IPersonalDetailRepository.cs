using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZydusFrontline.Entity.FamilyDetails;
using ZydusFrontline.Entity.Search;
using ZydusFrontline.Interface.Repository;

namespace ZydusFrontline.Interface.FamilyDetails
{
    public interface IPersonalDetailRepository : IRepository<PersonalDetailEntity, SearchEntity, bool>
    {
        Task<IQueryable<MemberEntity>> GetAllMember();
        Task<List<PersonalDetailEntity>> EntitiesSP(SearchEntity query);
    }
}
