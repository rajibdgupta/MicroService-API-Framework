using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZydusFrontline.Entity.FamilyDetails;
using ZydusFrontline.Entity.Search;
using ZydusFrontline.Interface.Services;

namespace ZydusFrontline.Interface.FamilyDetails
{

    public interface IPersonalDetailService : ISerivces<PersonalDetailEntity, SearchEntity, bool>
    {
        Task<List<MemberEntity>> GetAllMember();
        Task<List<PersonalDetailEntity>> FindSP(SearchEntity query);
    }
}
